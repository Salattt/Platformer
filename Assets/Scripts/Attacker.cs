using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Attacker : MonoBehaviour
{
    [SerializeField] private Controller _controller;
    [SerializeField] private float _attackTime;
    [SerializeField] private float _damage;

    private bool _isAttackPerformed = false;

    public event Action AttackStarted;

    public bool IsAttacking { get; private set; } = false;

    private void Update()
    {
        if (_controller.IsAtacking && IsAttacking == false)
            StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        IsAttacking = true;
        AttackStarted?.Invoke();

        yield return new WaitForSeconds(_attackTime);

        _isAttackPerformed = false;
        IsAttacking = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (IsAttacking && collision.TryGetComponent<IDamageable>(out IDamageable damageable) && _isAttackPerformed == false)
        {
            damageable.TakeDamage(_damage);

            _isAttackPerformed = true;
        }
    }
}
