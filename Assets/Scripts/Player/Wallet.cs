using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private Collector _item;

    private int _coinsNumber;

    private void OnEnable()
    {
        _item.CollectedCoin += TakeCoin;
    }

    private void OnDisable()
    {
        _item.CollectedCoin -= TakeCoin;
    }

    private void TakeCoin()
    {
        _coinsNumber++;
        Debug.Log(_coinsNumber);
    }
}