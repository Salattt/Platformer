using UnityEngine;

[RequireComponent (typeof(BoxCollider2D))]
public class AttackChecker : MonoBehaviour
{
    public bool IsPlayerSpotted { get; private set; } = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player player))
            IsPlayerSpotted = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
            IsPlayerSpotted = false;
    }
}
