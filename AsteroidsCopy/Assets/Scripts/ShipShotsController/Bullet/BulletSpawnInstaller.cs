using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawnInstaller : MonoBehaviour
{
    [SerializeField] private TemporaryMonoPooled bullet;
    [SerializeField] private TemporaryMonoPooled laser;

    private IBulletSpawner _bulletSpawner;

    private void Awake()
    {
        _bulletSpawner = new BulletSpawner(bullet, laser, transform);
    }

    private void OnEnable()
    {
        ServiceLocator.Subscribe<IBulletSpawner>(_bulletSpawner);
        ServiceLocator.Subscribe<ILaserSpawner>(_bulletSpawner);
    }

    private void OnDisable()
    {
        ServiceLocator.Unsubscribe<IBulletSpawner>();
        ServiceLocator.Unsubscribe<ILaserSpawner>();
    }
}