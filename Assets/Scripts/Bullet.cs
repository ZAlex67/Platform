using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 20f;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private int _damage = 10;

    private void Start()
    {
        _rb.velocity = transform.right * _speed;
    }

    private void Update()
    {
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();

        if (enemy != null)
        {
            Health health = collision.gameObject.GetComponent<Health>();
            health.TakeHit(_damage);
            Destroy(gameObject);
        }
    }
}