using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PlayerChecker : MonoBehaviour
{
    public event Action<Player> PlayerSpotted;
    public event Action PlayerLeave;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player player))
            PlayerSpotted?.Invoke(player);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
            PlayerLeave?.Invoke();
    }
}
