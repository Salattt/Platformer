using System;
using UnityEngine;

[RequireComponent(typeof(Mover))]
public class Player : Creature
{
    public void Heal(float heal)
    {
        if (heal < 0)
            throw new ArgumentOutOfRangeException(nameof(heal));

        _health += heal;
    }
}