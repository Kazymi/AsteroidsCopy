using UnityEngine;

public class ShipLaserController : ILivingCycle

{
    private float _currentCoolDown;
    private bool IsReadyToLaser => _currentCoolDown <= 0;
    private readonly ShipShooterConfiguration _shooterConfiguration;
    private readonly Transform _bulletSpawnPoint;
    private readonly IWeaponInput _weaponInput;
    private readonly ILaserSpawnerService _laserSpawner;


    public ShipLaserController(Transform bulletSpawnPoint, ShipShooterConfiguration shooterConfiguration,
        IWeaponInput weaponInput)
    {
        _laserSpawner = ServiceLocator.GetService<ILaserSpawnerService>();
        _bulletSpawnPoint = bulletSpawnPoint;
        _shooterConfiguration = shooterConfiguration;
        _weaponInput = weaponInput;
    }

    public void OnEnable()
    {
        _weaponInput.callLaser +=  LaserStart;
    }

    public void OnDisable()
    {
        _weaponInput.callLaser -= LaserStart;
    }

    public void Update(float deltaTime)
    {
        if (_currentCoolDown > 0)
        {
            _currentCoolDown -= deltaTime;
        }
    }

    private void LaserStart()
    {
        if (IsReadyToLaser == false)
        {
            return;
        }

        var laser = _laserSpawner.GetLaser();
        var transform = laser.transform;
        transform.parent = _bulletSpawnPoint;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        _currentCoolDown = _shooterConfiguration.LaserCoolDown;
    }
}