using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CoinsSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private List<Transform> _points;
    [SerializeField] private Collector _takeItem;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        Spawn();
    }

    private void OnEnable()
    {
        _takeItem.TookCoin += DectroyCoin;
    }

    private void OnDisable()
    {
        _takeItem.TookCoin -= DectroyCoin;
    }

    private void Spawn()
    {
        for (int i = 0; i < _points.Count; i++)
        {
            Instantiate(_coin, _points[i].position, _points[i].rotation);
        }
    }

    private void DectroyCoin(Coin coin)
    {
        _audioSource.Play();
        Destroy(coin.gameObject);
    }
}