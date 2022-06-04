public class MeteorHealth
{
    private readonly MeteorMovementController _movementController;
    private readonly IEnemySpawnerService _enemySpawnerService;

    private const int AmountSmallMeteor = 3;

    public MeteorHealth(MeteorMovementController movementController)
    {
        _movementController = movementController;
        _enemySpawnerService = ServiceLocator.GetService<IEnemySpawnerService>();
    }

    public void TakeDamage()
    {
        for (int i = 0; i < AmountSmallMeteor; i++)
        {
            var smallMeteor = _enemySpawnerService.SpawnEnemy(EnemyType.SmallMeteor);
            smallMeteor.position = _movementController.MeteorPosition;
        }
        _movementController.ReturnToPool();
    }
}