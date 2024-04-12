using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private Collector _item;

    private int _coinsNumber;

    private void OnEnable()
    {
        _item.TookCoin += TakeCoin;
    }

    private void OnDisable()
    {
        _item.TookCoin -= TakeCoin;
    }

    private void TakeCoin(Coin coin)
    {
        _coinsNumber++;
        Debug.Log(_coinsNumber);
    }
}