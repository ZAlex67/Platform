using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private PlayerTakeItem _item;

    private int _coinsNumber;

    private void OnEnable()
    {
        _item.CoinsNumber += TakeCoin;
    }

    private void OnDisable()
    {
        _item.CoinsNumber -= TakeCoin;
    }

    private void TakeCoin()
    {
        _coinsNumber++;
        Debug.Log(_coinsNumber);
    }
}