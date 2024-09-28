using UnityEngine;

public class BulletFactory : SpawnerGeneric<Bullet>
{
    [SerializeField] private Transform _firePoint;

    private void Awake()
    {
        CreatePool();
    }

    protected override void ActionOnGet(Bullet bullet)
    {
        bullet.SetFactory(this);
        bullet.transform.SetPositionAndRotation(_firePoint.position, _firePoint.rotation);
        bullet.gameObject.SetActive(true);
    }
}