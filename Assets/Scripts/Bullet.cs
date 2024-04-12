using UnityEngine;
using UnityEngine.Tilemaps;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 20f;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private int _damage = 10;
    [SerializeField] private float _timeDestroy = 4f;

    private void Start()
    {
        _rigidbody.velocity = transform.right * _speed;
    }

    private void Update()
    {
        Destroy(gameObject, _timeDestroy);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            Health health = collision.gameObject.GetComponent<Health>();
            health.TakeHit(_damage);
            Destroy(gameObject);
        }

        if (collision.TryGetComponent<Tilemap>(out Tilemap tilemap))
        {
            Destroy(gameObject);
        }
    }
}