using UnityEngine;
using UnityEngine.Pool;

public abstract class SpawnerGeneric<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _prefab;
    [SerializeField] private int _poolCapacity = 5;
    [SerializeField] private int _poolMaxSize = 5;

    private ObjectPool<T> _pool;

    public virtual void ReleaseObject(T prefab)
    {
        _pool.Release(prefab);
    }

    public virtual void GetPrefab()
    {
        _pool.Get();
    }

    protected void CreatePool()
    {
        _pool = new ObjectPool<T>(
            createFunc: () => Init(),
            actionOnGet: (obj) => ActionOnGet(obj),
            actionOnRelease: (obj) => obj.gameObject.SetActive(false),
            collectionCheck: false,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize);
    }

    protected virtual T Init()
    {
        return Instantiate(_prefab);
    }

    protected abstract void ActionOnGet(T prefab);
}