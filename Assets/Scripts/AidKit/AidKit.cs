using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class AidKit : MonoBehaviour
{
    [SerializeField] private float _heal;

    public void GetHeal(out float heal)
    {
        heal = _heal;

        Destroy(gameObject);
    }
}
