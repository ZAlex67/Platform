using UnityEngine;

[RequireComponent(typeof(Collector))]
[RequireComponent(typeof(IHeal))]
public class RestorePlayerHealth : MonoBehaviour
{
    [SerializeField] private int _heal = 20;

    private Collector _item;
    private IHeal _player;

    private void Awake()
    {
        _item = GetComponent<Collector>();
        _player = GetComponent<IHeal>();
    }

    private void OnEnable()
    {
        _item.TookHeal += OnRestoreHealth;
    }

    private void OnDisable()
    {
        _item.TookHeal -= OnRestoreHealth;
    }

    private void OnRestoreHealth(Heal heal)
    {
        _player.RestoreHealth(_heal);
    }
}