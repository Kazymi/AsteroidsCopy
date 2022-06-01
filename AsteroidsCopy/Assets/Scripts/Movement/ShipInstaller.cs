using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipInstaller : MonoBehaviour
{
    [SerializeField] private InputController inputController;
    [SerializeField] private Transform shipTransform;
    [SerializeField] private ShipMovementConfiguration shipMovementConfiguration;

    private IUpdatable _ship;

    private void Awake()
    {
        _ship = new ShipMovementController(shipTransform, shipMovementConfiguration, shipMovementConfiguration,
            inputController);
    }

    private void Update()
    {
        _ship.Update(Time.deltaTime);
    }
}