using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    [SerializeField] GroundDetector _detector;
    [SerializeField] Input _controller;
    [SerializeField] float _maxVelocity;
    [SerializeField] float _acceleration;
    [SerializeField] float _jumpForce;

    private Rigidbody2D _rigidbody;

    public float LastHorizontalVelocity { get; private set; }
    public bool IsGrounded { get {return _detector.IsGrounded; } }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        LastHorizontalVelocity = _rigidbody.velocity.x;
        _rigidbody.velocity = new Vector2(CalculateHorizontalVelocity(), _rigidbody.velocity.y);

        TryJump();
    }

    private float CalculateHorizontalVelocity()
    {
        float newVelocity = LastHorizontalVelocity + (_controller.MoveAxis.x * _acceleration * Time.fixedDeltaTime);

        if(Mathf.Abs(newVelocity) > _maxVelocity)
            return _maxVelocity * Mathf.Sign(newVelocity);

        return newVelocity;
    }

    private void TryJump()
    {
        if(_controller.MoveAxis.y > 0 && _detector.IsGrounded && Mathf.Abs(_rigidbody.velocity.y) <= 0.1)
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
}
