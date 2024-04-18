using UnityEngine;
using UnityEngine.UI;

public abstract class HealthBarSlider : HealthBar
{
    [SerializeField] protected Slider Slider;

    protected virtual void ChangeMaxHealth()
    {
        Slider.maxValue = HealthPoint.MaxHealth;
    }

    protected override void OnHealthUpdated()
    {
        ChangeMaxHealth();

        Slider.value = HealthPoint.CurrentHealth;
    }
}