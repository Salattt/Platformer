using UnityEngine;

public abstract class HeatlthView : MonoBehaviour
{
    [SerializeField] private Creature _creature;

    private void OnEnable()
    {
        _creature.HealthChanded += OnHealthChanged;
    }

    private void OnDisable()
    {
        _creature.HealthChanded -= OnHealthChanged;
    }

    private  void OnHealthChanged()
    {
        UpdateHealth(_creature.CurrentHealth, _creature.MaxHealth);
    }

    protected abstract void UpdateHealth(float currentHealth, float maxHealth);
}
