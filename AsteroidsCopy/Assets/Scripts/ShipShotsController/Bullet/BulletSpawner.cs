using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : IBulletSpawner
{
    private readonly IPool<TemporaryMonoPooled> _bulletPool;
    private const int StartAmountBulletInPool = 4;

    public BulletSpawner(TemporaryMonoPooled bullet, Transform parent)
    {
        ServiceLocator.Subscribe<IBulletSpawner>(this);
        var factory = new FactoryMonoObject<TemporaryMonoPooled>(bullet.gameObject, parent);
        _bulletPool = new Pool<TemporaryMonoPooled>(factory, StartAmountBulletInPool);
    }

    ~BulletSpawner()
    {
        ServiceLocator.Unsubscribe<IBulletSpawner>();
    }

    public void SpawnBullet(Vector3 spawnPosition, Quaternion spawnRotation)
    {
        var newBullet = _bulletPool.Pull().transform;
        newBullet.position = spawnPosition;
        newBullet.rotation = spawnRotation;
    }
}