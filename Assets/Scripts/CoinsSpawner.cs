using System.Collections.Generic;
using UnityEngine;

public class CoinsSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private List<Transform> _points;

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        List<Transform> points = _points;

        for (int i = 0; i < points.Count; i++)
        {
            Instantiate(_coin, points[i].position, points[i].rotation);
        }
    }
}