using UnityEngine;

public class ShipShotController : ILivingCycle

{
    private float _currentCoolDown;
    private bool IsReadyToShot => _currentCoolDown <= 0;
    private readonly ShipShooterConfiguration _shooterConfiguration;
    private readonly Transform _bulletSpawnPoint;
    private readonly IWeaponInput _weaponInput;
    private readonly IBulletSpawner _bulletSpawner;


    public ShipShotController(Transform bulletSpawnPoint, ShipShooterConfiguration shooterConfiguration,
        IWeaponInput weaponInput)
    {
        _bulletSpawner = ServiceLocator.GetService<IBulletSpawner>();
        _bulletSpawnPoint = bulletSpawnPoint;
        _shooterConfiguration = shooterConfiguration;
        _weaponInput = weaponInput;
    }

    public void OnEnable()
    {
        _weaponInput.callShot += Shot;
    }

    public void OnDisable()
    {
        _weaponInput.callShot -= Shot;
    }

    public void Update(float deltaTime)
    {
        if (_currentCoolDown > 0)
        {
            _currentCoolDown -= deltaTime;
        }
    }

    private void Shot()
    {
        if (IsReadyToShot == false)
        {
            return;
        }

        _bulletSpawner.SpawnBullet(_bulletSpawnPoint.position, _bulletSpawnPoint.rotation);
        _currentCoolDown = _shooterConfiguration.FireRate;
    }
}