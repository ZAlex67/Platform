using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private int _damage = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IHealth>(out IHealth health))
        {
            health.TakeHit(_damage);
        }
    }
}