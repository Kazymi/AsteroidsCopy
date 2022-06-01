using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooter : ILivingCycle
{
    private readonly ILivingCycle _shipShotController;
    private readonly ILivingCycle _shipLaserController;

    public ShipShooter(Transform bulletSpawnPoint, ShipShooterConfiguration shooterConfiguration,
        IWeaponInput weaponInput)
    {
        _shipShotController = new ShipShotController(bulletSpawnPoint, shooterConfiguration, weaponInput);
        _shipLaserController = new ShipLaserController(bulletSpawnPoint, shooterConfiguration, weaponInput);
    }

    public void OnEnable()
    {
        _shipShotController.OnEnable();
        _shipLaserController.OnEnable();
    }

    public void OnDisable()
    {
        _shipShotController.OnDisable();
        _shipLaserController.OnDisable();
    }

    public void Update(float deltaTime)
    {
        _shipLaserController.Update(deltaTime);
        _shipShotController.Update(deltaTime);
    }
}