using UnityEngine;

[RequireComponent(typeof(Mover))]
public class Player : Creature
{
    [SerializeField] private AidKitDetector _aidKitDetector;
    [SerializeField] private VampireAbility _vampire;

    protected override void OnEnable()
    {
        base.OnEnable();
        _aidKitDetector.HealReceived += Health.TakeHeal;
        _vampire.HealthRecived += Health.TakeHeal;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        _aidKitDetector.HealReceived -= Health.TakeHeal;
        _vampire.HealthRecived -= Health.TakeHeal;
    }
}