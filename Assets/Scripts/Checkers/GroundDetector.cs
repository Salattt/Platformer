using UnityEngine;

[RequireComponent (typeof(BoxCollider2D))]
public class GroundDetector : MonoBehaviour
{
    public bool IsGrounded { get; private set; } = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Ground>(out _))
            IsGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Ground>(out _))
            IsGrounded = false;
    }
}
