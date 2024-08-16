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

    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private Mover _mover;
    protected Health Hp;

    public Transform Transform { get; private set; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _mover = GetComponent<Mover>();
        Transform = transform;
        Hp = new Health(_maxHealth);
    }

    private void OnEnable()
    {
        _attacker.AttackStarted += OnAttackStarted;
    }

    private void OnDisable()
    {
        _attacker.AttackStarted -= OnAttackStarted;
    }

    private void Update()
    {
        _animator.SetBool(IsGrounded, _mover.IsGrounded);
        _animator.SetFloat(SpeedX, Mathf.Abs(_rigidbody.velocity.x));
        _animator.SetFloat(SpeedY, _rigidbody.velocity.y);
    }

    public void TakeDamage(float damage)
    {
        Hp.TakeDamage(damage);
    }

    private void OnAttackStarted()
    {
        _animator.SetTrigger(Attack);
    }

    private void Die()
    {
        _controller.TurnOff();
        _animator.SetTrigger(Death);
        Destroy(gameObject, _dieAnimationDuration);
    }
}
