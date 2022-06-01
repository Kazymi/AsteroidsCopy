using UnityEngine;

public class EnemySpawnerInstaller : MonoBehaviour
{
    [SerializeField] private TemporaryMonoPooled meteor;

    private EnemySpawner _enemySpawner;

    private void Awake()
    {
        _enemySpawner = new EnemySpawner(meteor, transform);
    }

    private void OnEnable()
    {
        ServiceLocator.Subscribe<IMeteorSpawnerService>(_enemySpawner);
    }

    private void OnDisable()
    {
        ServiceLocator.Unsubscribe<IMeteorSpawnerService>();
    }
}