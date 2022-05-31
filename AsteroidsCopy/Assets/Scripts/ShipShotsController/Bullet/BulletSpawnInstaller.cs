using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawnInstaller : MonoBehaviour
{
    [SerializeField] private TemporaryMonoPooled bullet;

    private void Awake()
    {
        var bulletSpawner = new BulletSpawner(bullet, transform);
    }
}