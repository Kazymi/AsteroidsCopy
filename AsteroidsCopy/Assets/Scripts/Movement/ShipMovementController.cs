using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovementController : IUpdatable
{
    private readonly Transform _shipTransform;
    private readonly IMovementInput _inputController;

    private readonly ShipAccelerationController _shipAccelerationController;
    private readonly ShipRotateController _shipRotateController;

    public ShipMovementController(Transform shipTransform, IMovementConfiguration shipMovementConfiguration,
        IShipRotationConfiguration rotationConfiguration,
        IMovementInput inputController)
    {
        _shipTransform = shipTransform;
        _inputController = inputController;

        _shipAccelerationController = new ShipAccelerationController(shipMovementConfiguration);
        _shipRotateController = new ShipRotateController(rotationConfiguration);
    }

    private void UpdateMovement()
    {
        var deltaTime = Time.deltaTime;
        UpdateShipPosition(_inputController.MovementVector.y > 0
            ? _shipAccelerationController.Move(_shipTransform.up, deltaTime)
            : _shipAccelerationController.Slowdown(deltaTime));

        if (_inputController.MovementVector.x != 0)
        {
            UpdateShipRotation(_shipRotateController.Rotate(deltaTime, _inputController.MovementVector.x));
        }
    }

    private void UpdateShipPosition(Vector2 moveVector)
    {
        _shipTransform.position += new Vector3(moveVector.x, moveVector.y, 0);
    }

    private void UpdateShipRotation(Quaternion newRotate)
    {
        _shipTransform.rotation = newRotate;
    }

    public void Update(float deltaTime)
    {
        UpdateMovement();
    }
}

public interface IUpdatable
{
    void Update(float deltaTime);
}