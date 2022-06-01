using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAndLaserSpawnerInstaller : MonoBehaviour
{
    [SerializeField] private TemporaryMonoPooled bullet;
    [SerializeField] private TemporaryMonoPooled laser;

    private WeaponComponentSpawner _weaponComSpawnerService;

    private void Awake()
    {
        _weaponComSpawnerService = new WeaponComponentSpawner(bullet, laser, transform);
    }

    private void OnEnable()
    {
        ServiceLocator.Subscribe<IBulletSpawnerService>(_weaponComSpawnerService);
        ServiceLocator.Subscribe<ILaserSpawnerService>(_weaponComSpawnerService);
    }

    private void OnDisable()
    {
        ServiceLocator.Unsubscribe<IBulletSpawnerService>();
        ServiceLocator.Unsubscribe<ILaserSpawnerService>();
    }
}