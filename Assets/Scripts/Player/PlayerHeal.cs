using UnityEngine;

public class PlayerHeal : MonoBehaviour
{
    [SerializeField] private int _heal = 20;
    [SerializeField] private Player _player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_player)
        {
            Health health = collision.gameObject.GetComponent<Health>();
            health.SetHealth(_heal);
            Destroy(gameObject);
        }
    }
}