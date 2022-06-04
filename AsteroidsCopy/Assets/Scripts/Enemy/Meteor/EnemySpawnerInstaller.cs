using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerInstaller : MonoBehaviour
{
    [SerializeField] private List<SpawnEnemyConfiguration> enemyConfigurations;

    private EnemySpawner _enemySpawner;

    private void Awake()
    {
        _enemySpawner = new EnemySpawner(enemyConfigurations, transform);
    }

    private void OnEnable()
    {
        ServiceLocator.Subscribe<IEnemySpawnerService>(_enemySpawner);
    }

    private void OnDisable()
    {
        ServiceLocator.Unsubscribe<IEnemySpawnerService>();
    }
}