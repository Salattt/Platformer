using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent (typeof(Controller))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Mover))]
public class Creature : MonoBehaviour, IDamageable
{
    [SerializeField] private Attacker _attacker;
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _dieAnimationDuration;
    [SerializeField] private Controller _controller;

    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private Mover _mover;
    protected float _health;

    public Transform Transform { get; private set; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _mover = GetComponent<Mover>();
        _health = _maxHealth;
        Transform = transform;
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
        _animator.SetBool("IsGrounded", _mover.IsGrounded);
        _animator.SetFloat("SpeedX", Mathf.Abs(_rigidbody.velocity.x));
        _animator.SetFloat("SpeedY", _rigidbody.velocity.y);
    }

    public void TakeDamage(float damage)
    {
        if (damage <= 0)
            throw new ArgumentOutOfRangeException(nameof(damage));

        _health -= damage;

        if(_health <= 0)
        {
            _health = 0;
            Die();
        }
    }

    private void OnAttackStarted()
    {
        _animator.SetTrigger("Attack");
    }

    private void Die()
    {
        _controller.TurnOff();
        _animator.SetTrigger("Death");
        Destroy(gameObject, _dieAnimationDuration);
    }
}
