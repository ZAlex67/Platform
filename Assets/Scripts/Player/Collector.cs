using System;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public event Action<Coin> TookCoin;
    public event Action<Heal> TookHeal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            TookCoin?.Invoke(coin);
        }

        if (collision.TryGetComponent<Heal>(out Heal heal))
        {
            TookHeal?.Invoke(heal);
        }
    }
}