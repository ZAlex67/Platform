using UnityEngine;
using UnityEngine.Tilemaps;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 20f;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private int _damage = 10;
    [SerializeField] private float _timeDestroy = 4f;

    private void Start()
    {
        _rb.velocity = transform.right * _speed;
    }

    private void Update()
    {
        Destroy(gameObject, _timeDestroy);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        Tilemap tilemap = collision.GetComponent<Tilemap>();

        if (enemy != null)
        {
            Health health = collision.gameObject.GetComponent<Health>();
            health.TakeHit(_damage);
            Destroy(gameObject);
        }

        if (tilemap != null)
        {
            Destroy(gameObject);
        }
    }
}