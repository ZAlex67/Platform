using System.Collections.Generic;
using UnityEngine;

public class CoinsSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private List<Transform> _points;
    [SerializeField] private Collector _takeItem;

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
        Destroy(coin.gameObject);
    }
}