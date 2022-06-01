using UnityEngine;

public class BulletEngineController
{
    private readonly BulletEngineConfiguration _bulletEngineConfiguration;

    public BulletEngineController(BulletEngineConfiguration bulletEngineConfiguration)
    {
        _bulletEngineConfiguration = bulletEngineConfiguration;
    }

    public Vector3 Move(Vector2 forward, float deltaTime)
    {
        return forward * (_bulletEngineConfiguration.Speed * deltaTime);
    }
}