using System.Collections.Generic;
using UnityEngine;

public class CoinsSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private List<Transform> _points;
    [SerializeField] private PlayerTakeItem _takeItem;

    private void Start()
    {
        Spawn();
    }

    private void OnEnable()
    {
        _takeItem.TakeCoin += DectroyCoin;
    }

    private void OnDisable()
    {
        _takeItem.TakeCoin -= DectroyCoin;
    }

    private void Spawn()
    {
        List<Transform> points = _points;

        for (int i = 0; i < points.Count; i++)
        {
            Instantiate(_coin, points[i].position, points[i].rotation);
        }
    }

    private void DectroyCoin(Coin coin)
    {
        Destroy(coin.gameObject);
    }
}