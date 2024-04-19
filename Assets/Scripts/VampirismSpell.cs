using System.Collections;
using UnityEngine;

public class VampirismSpell : MonoBehaviour
{
    [SerializeField] private float _healthRatio;
    [SerializeField] private InputPlayer _input;

    private Player _player;
    private Collider2D _circle;
    private Coroutine _coroutine;

    private void Start()
    {
        _player = GetComponent<Player>();
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

        _coroutine = StartCoroutine(Vampirism());
    }

    private IEnumerator Vampirism()
    {
        float currentTime = 6f;
        float radius = 8f;

        while (currentTime > float.Epsilon)
        {
            _circle = Physics2D.OverlapCircle(transform.position, radius);

            if (_circle.TryGetComponent(out Enemy enemy))
            {
                enemy.GetComponent<Health>().TakeHit(_healthRatio * Time.deltaTime);
                _player.GetComponent<Health>().SetHealth(_healthRatio * Time.deltaTime);
                currentTime -= Time.deltaTime;
                Debug.Log(currentTime);
            }

            yield return null;
        }
    }
}