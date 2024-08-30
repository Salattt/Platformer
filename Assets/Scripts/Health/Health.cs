using System;

public class Health : IDamageable
{
    public Health(float maxHealth)
    {
        Max = maxHealth;
        Current = maxHealth;
    }

    public event Action Die;
    public event Action HealthChanded;

    public float Current {  get; private set; }
    public float Max { get;}

    public void TakeDamage(float damage)
    {
        if (damage < 0)
            throw new ArgumentOutOfRangeException(nameof(damage));

        Current -= damage;

        if(Current <= 0)
        {
            Current = 0;
            Die?.Invoke();
        }

        HealthChanded?.Invoke();
    }

    public void TakeHeal(float heal)
    {
        if (heal < 0)
            throw new ArgumentOutOfRangeException(nameof(heal));

        Current += heal;

        if (Current >= Max)
            Current = Max;

        HealthChanded?.Invoke();
    }
}
