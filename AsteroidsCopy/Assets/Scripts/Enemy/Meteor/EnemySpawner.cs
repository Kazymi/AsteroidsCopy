using UnityEngine;

public class EnemySpawner : IMeteorSpawnerService
{
    private readonly IPool<TemporaryMonoPooled> _meteorPool;
    private const int AmountEnemyInPool = 3;

    public EnemySpawner(TemporaryMonoPooled meteor, Transform parent)
    {
        var meteorFactory = new FactoryMonoObject<TemporaryMonoPooled>(meteor.gameObject, parent);
        _meteorPool = new Pool<TemporaryMonoPooled>(meteorFactory, AmountEnemyInPool);
    }

    public void SpawnMeteor()
    {
        _meteorPool.Pull();
    }
}