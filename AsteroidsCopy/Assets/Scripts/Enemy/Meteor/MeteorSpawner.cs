public class MeteorSpawner : IUpdatable
{
    private readonly float _spawnInterval;
    private readonly IMeteorSpawnerService _meteorSpawnerService;
    private float _currentTime;

    public MeteorSpawner(float spawnInterval)
    {
        _spawnInterval = spawnInterval;
        _meteorSpawnerService = ServiceLocator.GetService<IMeteorSpawnerService>();
    }

    public void Update(float deltaTime)
    {
        if (_currentTime < 0)
        {
            _currentTime = _spawnInterval;
            SpawnMeteor();
        }
        else
        {
            _currentTime -= deltaTime;
        }
    }

    private void SpawnMeteor()
    {
        _meteorSpawnerService.SpawnMeteor();
    }
}