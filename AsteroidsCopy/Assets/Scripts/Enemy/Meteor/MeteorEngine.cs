using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorEngine
{
    private readonly IMapPositionGeneratorService _mapPositionGeneratorService;
    private readonly MeteorConfiguration _meteorConfiguration;
    
    private Vector2 _currentPosition;

    public MeteorEngine(MeteorConfiguration meteorConfiguration)
    {
        _meteorConfiguration = meteorConfiguration;
        _mapPositionGeneratorService = ServiceLocator.GetService<IMapPositionGeneratorService>();
    }

    public void Initialize(Transform meteorTransform)
    {
        _currentPosition = _mapPositionGeneratorService.GetRandomPositionOutsideMap();
        var movementDirection = _mapPositionGeneratorService.GetRandomPositionInsideMap() - _currentPosition;
        meteorTransform.LookAt(new Vector3(movementDirection.x,movementDirection.y,meteorTransform.position.z));
    }

    public Vector3 Move(float deltaTime,Vector2 vectorForward)
    {
        _currentPosition += vectorForward * (_meteorConfiguration.MeteorSpeed * deltaTime);
        return _currentPosition;
    }
}