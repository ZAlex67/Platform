using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField, Range(0, 100)] private float _health;
    [SerializeField, Range(0, 100)] private float _maxHealth;
    [SerializeField] private Death _death;

    public event Action CheckedHealth;

    public float CurrentHealth => _health;
    public float MaxHealth => _maxHealth;

    public void TakeHit(float damage)
    {
        if (damage >= 0)
            _health = Mathf.Clamp(_health -= damage, 0, _maxHealth);

        if (_health <= 0)
            Die();

        CheckedHealth?.Invoke();
    }

    public void RestoreHealth(float health)
    {
        if (health >= 0)
            _health = Mathf.Clamp(_health += health, 0, _maxHealth);

        CheckedHealth?.Invoke();
    }

    private void Die()
    {
        Destroy(gameObject);
        Instantiate(_death, transform.position, Quaternion.identity);
    }
}