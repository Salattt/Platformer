using System;

public interface IDamageable 
{
    public event Action HealthChanded;

    void TakeDamage(float damage);
}
