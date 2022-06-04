using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class EnemySpawner : IEnemySpawnerService
{
    private readonly Dictionary<EnemyType, IPool<TemporaryMonoPooled>> _enemiesPool =
        new Dictionary<EnemyType, IPool<TemporaryMonoPooled>>();

    private const int AmountEnemyInPool = 3;

    public EnemySpawner(IEnumerable<SpawnEnemyConfiguration> enemies, Transform parent)
    {
        foreach (var spawnEnemyConfiguration in enemies)
        {
            if (_enemiesPool.ContainsKey(spawnEnemyConfiguration.EnemyType))
            {
                Debug.LogWarning($"{spawnEnemyConfiguration.EnemyType} already added to the list");
                return;
            }

            var enemyFactory =
                new FactoryMonoObject<TemporaryMonoPooled>(spawnEnemyConfiguration.Enemy.gameObject, parent);
            var pool = new Pool<TemporaryMonoPooled>(enemyFactory, AmountEnemyInPool);
            _enemiesPool.Add(spawnEnemyConfiguration.EnemyType, pool);
        }
    }

    public Transform SpawnEnemy(EnemyType enemyType)
    {
        if (_enemiesPool.ContainsKey(enemyType))
        {
            return _enemiesPool[enemyType].Pull().transform;
        }

        Debug.LogWarning($"{enemyType} not added to the list");
        return null;
    }
}

public enum EnemyType
{
    Meteor,
    SmallMeteor,
    EnemyShip
}

[Serializable]
public class SpawnEnemyConfiguration
{
    [SerializeField] private TemporaryMonoPooled enemy;
    [SerializeField] private EnemyType enemyType;

    public TemporaryMonoPooled Enemy => enemy;

    public EnemyType EnemyType => enemyType;
}