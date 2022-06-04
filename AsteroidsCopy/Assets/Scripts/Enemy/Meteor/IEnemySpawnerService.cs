using UnityEngine;

public interface IEnemySpawnerService
{
    Transform SpawnEnemy(EnemyType enemyType);
}