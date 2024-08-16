using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PlayerDetector : MonoBehaviour
{
    public event Action<Player> Spotted;
    public event Action Leave;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
            Spotted?.Invoke(player);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
            Leave?.Invoke();
    }
}
