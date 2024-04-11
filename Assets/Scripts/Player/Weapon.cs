using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private InputPlayer _input;

    private void OnEnable()
    {
        _input.Shoot += ShootAction;
    }

    private void OnDisable()
    {
        _input.Shoot -= ShootAction;
    }

    private void ShootAction()
    {
        Instantiate(_bullet, _firePoint.position, _firePoint.rotation);
    }
}