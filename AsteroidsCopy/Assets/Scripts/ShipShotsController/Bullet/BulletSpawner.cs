using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : IBulletSpawner,ILaserSpawner
{
    private readonly IPool<TemporaryMonoPooled> _bulletPool;
    private readonly IPool<TemporaryMonoPooled> _laserPool;
    private const int StartAmountBulletInPool = 4;

    public BulletSpawner(TemporaryMonoPooled bulletPrefab, TemporaryMonoPooled laserPrefab, Transform parent)
    {
        var bulletFactory = new FactoryMonoObject<TemporaryMonoPooled>(bulletPrefab.gameObject, parent);
        _bulletPool = new Pool<TemporaryMonoPooled>(bulletFactory, StartAmountBulletInPool);

        var laserFactory = new FactoryMonoObject<TemporaryMonoPooled>(laserPrefab.gameObject, parent);
        _laserPool = new Pool<TemporaryMonoPooled>(laserFactory, StartAmountBulletInPool);
    }

    public void SpawnBullet(Vector3 spawnPosition, Quaternion spawnRotation)
    {
        var newBullet = _bulletPool.Pull().transform;
        newBullet.position = spawnPosition;
        newBullet.rotation = spawnRotation;
    }

    public TemporaryMonoPooled GetLaser()
    {
        return _laserPool.Pull();
    }
}