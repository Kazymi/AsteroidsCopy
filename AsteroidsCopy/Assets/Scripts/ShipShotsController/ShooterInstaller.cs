using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterInstaller : MonoBehaviour
{
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private ShipShooterConfiguration shooterConfiguration;
    private ILivingCycle _shooter;

    private void Start()
    {
        var weaponInput = ServiceLocator.GetService<IWeaponInput>();
        _shooter = new ShipShooter(bulletSpawnPoint, shooterConfiguration, weaponInput);
        _shooter.OnEnable();
    }

    private void Update()
    {
        _shooter.Update(Time.deltaTime);
    }

    private void OnDisable()
    {
        _shooter?.OnDisable();
    }

    private void OnEnable()
    {
        _shooter?.OnEnable();
    }
}