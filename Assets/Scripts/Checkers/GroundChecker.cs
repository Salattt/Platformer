using UnityEngine;

[RequireComponent (typeof(BoxCollider2D))]
public class GroundChecker : MonoBehaviour
{
    public bool IsGrounded { get; private set; } = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Ground>(out Ground ground))
            IsGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Ground>(out Ground ground))
            IsGrounded = false;
    }
}
