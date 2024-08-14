using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Controller
{
    [SerializeField] private List<PlayerChecker> _playerCheckers;
    [SerializeField] private AttackChecker _attackChecker;
    [SerializeField] private GroundChecker _wallChecker;

    private Transform _transform;
    private Player _target;
    private bool _isStalking = false;
    private float _currentXMoveAxis = 1;

    private void Awake()
    {
        _transform = transform;
    }

    private void OnEnable()
    {
        foreach (PlayerChecker checker in _playerCheckers)
        {
            checker.PlayerSpotted += OnPlaeyrSpotted;
        }
    }

    private void OnDisable()
    {
        foreach (PlayerChecker checker in _playerCheckers)
        {
            checker.PlayerSpotted -= OnPlaeyrSpotted;
        }
    }

    private void Update()
    {
        if (_attackChecker.IsPlayerSpotted)
        {
            IsAtacking = true;
            MoveAxis = Vector2.zero;
            return;
        }

        IsAtacking = false;

        if (_isStalking)
        {
            MoveAxis = new Vector2(Mathf.Sign(_target.Transform.position.x - _transform.position.x),0);
            return;
        }

        if (_wallChecker.IsGrounded)
        {
            _currentXMoveAxis *= -1;
        }

        MoveAxis = new Vector2(_currentXMoveAxis, 0);
    }

    private void OnPlaeyrSpotted(Player player)
    {
        _target = player;
        _isStalking = true;
    }
}
