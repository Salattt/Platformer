using System;
using UnityEngine;

[RequireComponent(typeof(Mover))]
public class Player : Creature
{
    [SerializeField] private AidKitDetector _aidKitDetector;

    private void OnEnable()
    {
        _aidKitDetector.HealReceived += OnHealReceived;
    }

    private void OnDisable()
    {
        _aidKitDetector.HealReceived -= OnHealReceived;
    }

    public void OnHealReceived(float heal)
    {
        Hp.TakeHeal(heal);
    }
}