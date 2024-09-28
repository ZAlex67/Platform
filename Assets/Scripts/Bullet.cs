using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 20f;
    [SerializeField] private int _damage = 10;

    private Rigidbody2D _rigidbody;
    private BulletFactory _factory;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _rigidbody.velocity = transform.right * _speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IHealth>(out IHealth health))
        {
            health.TakeHit(_damage);
            _factory.ReleaseObject(this);
        }

        if (collision.TryGetComponent<Ground>(out Ground ground))
        {
            _factory.ReleaseObject(this);
        }
    }

    public void SetFactory(BulletFactory factory)
    {
        _factory = factory;
    }
}