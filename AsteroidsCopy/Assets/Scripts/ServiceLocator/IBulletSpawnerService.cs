using UnityEngine;

public interface IBulletSpawnerService
{
    void SpawnBullet(Vector3 spawnPosition, Quaternion spawnRotation);
}