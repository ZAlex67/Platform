using System;
using UnityEngine;

public class PlayerTakeItem : MonoBehaviour
{
    public event Action<Coin> TakeCoin;
    public event Action CoinsNumber;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            TakeCoin?.Invoke(coin);
            CoinsNumber?.Invoke();
        }
    }
}