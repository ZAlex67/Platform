using System.Collections;
using UnityEngine;

public class VampirismSpell : MonoBehaviour
{
    [SerializeField] private float _healthRatio;
    [SerializeField] private InputPlayer _input;
    [SerializeField] private Transform _point;

    private Health _player;
    private Collider2D _circle;
    private Coroutine _coroutine;
    private float _cooldownTime = 7f;
    private float _lastTimeCasted;
    private float _radius = 7f;

    private void Start()
    {
        _player = GetComponent<Health>();
    }

    private void Update()
    {
        _circle = Physics2D.OverlapCircle(transform.position, _radius);

        if (_circle.TryGetComponent(out Enemy enemy))
        {
            if ((Vector2.Distance(transform.position, enemy.transform.position) > _radius) && _coroutine != null)
            {
                StopCoroutine(_coroutine);
            }
        }
    }

    private void OnEnable()
    {
        _input.Vampirisming += OnHealthTransferred;
    }

    private void OnDisable()
    {
        _input.Vampirisming -= OnHealthTransferred;
    }

    private void OnHealthTransferred()
    {

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        if (Time.time < _lastTimeCasted + _cooldownTime)
            return;

        if (_circle.TryGetComponent(out Enemy enemy))
        {
            _coroutine = StartCoroutine(Vampirism(enemy));
        }

        _lastTimeCasted = Time.time;
    }

    private IEnumerator Vampirism(Enemy enemy)
    {
        float currentTime = 6f;

        while ((currentTime > float.Epsilon) && (enemy != null))
        {
            enemy.GetComponent<Health>().TakeHit(_healthRatio * Time.deltaTime);
            _player.RestoreHealth(_healthRatio * Time.deltaTime);
            currentTime -= Time.deltaTime;

            Debug.Log(currentTime);

            yield return null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(_point.position, _radius);
    }
}