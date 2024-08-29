using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent (typeof(Input))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Mover))]
public class Creature : MonoBehaviour, IDamageable
{
    private const string IsGrounded = "IsGrounded";
    private const string SpeedX = "SpeedX";
    private const string SpeedY = "SpeedY";
    private const string Attack = "Attack";
    private const string Death = "Death";

    [SerializeField] private Attacker _attacker;
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _dieAnimationDuration;
    [SerializeField] private Input _controller;

    protected Health Health;
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private Mover _mover;

    public event Action HealthChanded;

    public Transform Transform { get; private set; }
    public float MaxHealth { get { return Health.Max; } }
    public float CurrentHealth {  get { return Health.Current; } }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _mover = GetComponent<Mover>();
        Transform = transform;
        Health = new Health(_maxHealth);
    }

    protected virtual void OnEnable()
    {
        _attacker.AttackStarted += OnAttackStarted;
        Health.Die += OnDie;
        Health.HealthChanded += OnHealthChanded;
        HealthChanded?.Invoke();
        Debug.Log("asd");
    }

    protected virtual void OnDisable()
    {
        _attacker.AttackStarted -= OnAttackStarted;
        Health.Die -= OnDie;
        Health.HealthChanded -= OnHealthChanded;
    }

    private void Update()
    {
        _animator.SetBool(IsGrounded, _mover.IsGrounded);
        _animator.SetFloat(SpeedX, Mathf.Abs(_rigidbody.velocity.x));
        _animator.SetFloat(SpeedY, _rigidbody.velocity.y);
    }

    public void TakeDamage(float damage)
    {
        Health.TakeDamage(damage);
    }

    private void OnAttackStarted()
    {
        _animator.SetTrigger(Attack);
    }

    private void OnDie()
    {
        _controller.TurnOff();
        _animator.SetTrigger(Death);
        Destroy(gameObject, _dieAnimationDuration);
    }

    private void OnHealthChanded()
    {
        HealthChanded?.Invoke();
    }
}
