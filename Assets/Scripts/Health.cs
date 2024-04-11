using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _maxHealth;
    [SerializeField] private Death _death;

    public void TakeHit(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Die();
        }
    }

    public void SetHealth(int health)
    {
        _health += health;

        if (_health > _maxHealth)
            _health = _maxHealth;
    }

    private void Die()
    {
        Destroy(gameObject);
        //Instantiate(_death, transform.position, Quaternion.identity);
    }
}