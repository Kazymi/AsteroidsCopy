using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovementController : MonoBehaviour
{
    [SerializeField] private Transform bulletTransform;
    [SerializeField] private BulletEngineConfiguration bulletEngineConfiguration;
    
    private BulletEngineController _bulletEngineController;
    private void Awake()
    {
        _bulletEngineController = new BulletEngineController(bulletEngineConfiguration);
    }

    private void Update()
    {
        bulletTransform.position += _bulletEngineController.Move(bulletTransform.up, Time.deltaTime);
    }
}