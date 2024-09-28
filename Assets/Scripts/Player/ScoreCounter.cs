using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private Collector _item;

    private int _coinsNumber;

    public event Action<int> ScoreChanged;

    private void OnEnable()
    {
        _item.TookCoin += OnTakeCoin;
    }

    private void OnDisable()
    {
        _item.TookCoin -= OnTakeCoin;
    }

    private void OnTakeCoin(Coin coin)
    {
        _coinsNumber++;
        ScoreChanged?.Invoke(_coinsNumber);
    }
}