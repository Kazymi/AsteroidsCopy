using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAccelerationController
{
    private readonly IMovementConfiguration _shipMovementConfiguration;
    private Vector2 _currentAcceleration;

    public ShipAccelerationController(IMovementConfiguration shipMovementConfiguration)
    {
        _shipMovementConfiguration = shipMovementConfiguration;
    }

    public Vector2 Move(Vector2 forward, float deltaTime)
    {
        _currentAcceleration += forward * (_shipMovementConfiguration.Speed * deltaTime);
        _currentAcceleration = ClampMagnitude(_currentAcceleration, _shipMovementConfiguration.MaxAcceleration);
        return _currentAcceleration;
    }

    public Vector2 Slowdown(float deltaTime)
    {
        _currentAcceleration -= _currentAcceleration * (deltaTime / _shipMovementConfiguration.StopTime);
        return _currentAcceleration;
    }

    private Vector2 ClampMagnitude(Vector2 vector, float maxLength)
    {
        var magnitude = GetMagnitude(_currentAcceleration);
        if (magnitude <= maxLength * maxLength)
        {
            return vector;
        }
        magnitude = (float) Math.Sqrt(magnitude);
        var newX = vector.x / magnitude;
        var newY = vector.y / magnitude;
        return new Vector2(newX * maxLength, newY * maxLength);
    }

    private float GetMagnitude(Vector2 direction)
    {
        return direction.x * direction.x +
               direction.y * direction.y;
    }
}