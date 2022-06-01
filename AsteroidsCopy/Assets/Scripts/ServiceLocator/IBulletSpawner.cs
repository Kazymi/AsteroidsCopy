using UnityEngine;

public interface IBulletSpawner
{
    void SpawnBullet(Vector3 spawnPosition, Quaternion spawnRotation);
}

public interface ILaserSpawner
{
    TemporaryMonoPooled GetLaser();
}