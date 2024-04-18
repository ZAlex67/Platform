using UnityEngine;

public abstract class HealthBar : MonoBehaviour
{
    [SerializeField] protected Health HealthPoint;

    private void Start()
    {
        OnHealthUpdated();
    }

    private void OnEnable()
    {
        HealthPoint.CheckedHealth += OnHealthUpdated;
    }

    private void OnDisable()
    {
        HealthPoint.CheckedHealth -= OnHealthUpdated;
    }

    protected abstract void OnHealthUpdated();
}