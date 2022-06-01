using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorEngine
{
    private readonly IMapPositionGeneratorService _mapPositionGeneratorService;
    private readonly MeteorConfiguration _meteorConfiguration;

    private Vector2 _movementDirection;
    private Vector2 _currentPosition;

    public MeteorEngine(MeteorConfiguration meteorConfiguration)
    {
        _meteorConfiguration = meteorConfiguration;
        _mapPositionGeneratorService = ServiceLocator.GetService<IMapPositionGeneratorService>();
    }

    public void Initialize()
    {
        _currentPosition = _mapPositionGeneratorService.GetRandomPositionOutsideMap();
        _movementDirection = _mapPositionGeneratorService.GetRandomPositionInsideMap() - _currentPosition;
    }

    public Vector3 Move(float deltaTime)
    {
        _currentPosition += _movementDirection * (_meteorConfiguration.MeteorSpeed * deltaTime);
        return _currentPosition;
    }
}