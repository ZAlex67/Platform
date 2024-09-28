using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class HealSpawner : MonoBehaviour
{
    [SerializeField] private Heal _heal;
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
        _takeItem.TookHeal += DectroyHeal;
    }

    private void OnDisable()
    {
        _takeItem.TookHeal -= DectroyHeal;
    }

    private void Spawn()
    {
        for (int i = 0; i < _points.Count; i++)
        {
            Instantiate(_heal, _points[i].position, _points[i].rotation);
        }
    }

    private void DectroyHeal(Heal heal)
    {
        _audioSource.Play();
        Destroy(heal.gameObject);
    }
}