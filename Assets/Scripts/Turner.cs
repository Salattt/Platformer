using UnityEngine;

public class Turner : MonoBehaviour
{
    [SerializeField] private Mover _mover;

    private Transform _transform;
    private int _lastVelocitySign = 1;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        if(_lastVelocitySign != Mathf.Sign(_mover.LastHorizontalVelocity) && Mathf.Abs(_mover.LastHorizontalVelocity) > 0.01) 
        { 
            _transform.localScale = new Vector3(-_transform.localScale.x, _transform.localScale.y, _transform.localScale.z);
            _lastVelocitySign = _lastVelocitySign * -1;
        }
    }
}
