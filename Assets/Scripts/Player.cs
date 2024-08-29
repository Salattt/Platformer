using UnityEngine;

[RequireComponent(typeof(Mover))]
public class Player : Creature
{
    [SerializeField] private AidKitDetector _aidKitDetector;

    protected override void OnEnable()
    {
        base.OnEnable();
        _aidKitDetector.HealReceived += OnHealReceived;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        _aidKitDetector.HealReceived -= OnHealReceived;
    }

    public void OnHealReceived(float heal)
    {
        Health.TakeHeal(heal);
    }
}