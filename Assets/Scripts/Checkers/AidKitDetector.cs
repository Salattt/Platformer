using System;
using UnityEngine;

public class AidKitDetector : MonoBehaviour
{
    public event Action<float> HealReceived;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out AidKit aidkit))
        {
            aidkit.GetHeal(out float heal);

            HealReceived?.Invoke(heal);
        }
    }
}
