using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private int _damage = 10;
    [SerializeField] private Player _player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_player)
        {
            Health health = collision.gameObject.GetComponent<Health>();
            health.TakeHit(_damage);
        }
    }
}