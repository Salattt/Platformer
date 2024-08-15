using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class AidKit : MonoBehaviour
{
    [SerializeField] private float _heal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player player))
        {
            player.Heal(_heal);

            Destroy(gameObject);
        }
    }
}
