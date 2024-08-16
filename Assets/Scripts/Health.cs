using System;

public class Health : IDamageable
{
    public Health(float maxHealth)
    {
        MaxHealth = maxHealth;
        Hp = maxHealth;
    }

    public event Action Die;

    public float Hp {  get; private set; }
    public float MaxHealth { get;}

    public void TakeDamage(float damage)
    {
        if (damage < 0)
            throw new ArgumentOutOfRangeException(nameof(damage));

        Hp -= damage;

        if(Hp <= 0)
        {
            Hp = 0;
            Die?.Invoke();
        }
    }

    public void TakeHeal(float heal)
    {
        if (heal < 0)
            throw new ArgumentOutOfRangeException(nameof(heal));

        Hp += heal;

        if (Hp >= MaxHealth)
            Hp = MaxHealth;
    }
}
