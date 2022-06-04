using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigMeteorEngine : MeteorEngine
{
    private readonly IMapPositionGeneratorService _mapPositionGeneratorService;
    private readonly MeteorConfiguration _meteorConfiguration;

    private Vector2 _currentPosition;

    public BigMeteorEngine(MeteorConfiguration meteorConfiguration)
    {
        _meteorConfiguration = meteorConfiguration;
        _mapPositionGeneratorService = ServiceLocator.GetService<IMapPositionGeneratorService>();
    }

    public override void Initialize(Transform meteorTransform)
    {
        _currentPosition = _mapPositionGeneratorService.GetRandomPositionOutsideMap();
        var movementDirection = _mapPositionGeneratorService.GetRandomPositionInsideMap() - _currentPosition;
        meteorTransform.LookAt(new Vector3(movementDirection.x, movementDirection.y, meteorTransform.position.z));
    }

    public override Vector3 Move(float deltaTime, Vector2 vectorForward)
    {
        _currentPosition += vectorForward * (_meteorConfiguration.MeteorSpeed * deltaTime);
        return _currentPosition;
    }
}

public class SmallMeteorEngine : MeteorEngine
{
    private readonly IMapPositionGeneratorService _mapPositionGeneratorService;
    private readonly MeteorConfiguration _meteorConfiguration;

    private Vector2 _currentPosition;

    public SmallMeteorEngine(MeteorConfiguration meteorConfiguration)
    {
        _meteorConfiguration = meteorConfiguration;
        _mapPositionGeneratorService = ServiceLocator.GetService<IMapPositionGeneratorService>();
    }

    public override void Initialize(Transform meteorTransform)
    {
        var meteorPosition = meteorTransform.position;
        _currentPosition = meteorPosition;
        var movementDirection = _mapPositionGeneratorService.GetRandomPositionInsideMap() - _currentPosition;
        meteorTransform.LookAt(new Vector3(movementDirection.x, movementDirection.y, meteorPosition.z));
    }

    public override Vector3 Move(float deltaTime, Vector2 vectorForward)
    {
        _currentPosition += vectorForward * (_meteorConfiguration.MeteorSpeed * deltaTime);
        return _currentPosition;
    }
}

public abstract class MeteorEngine
{
    public abstract void Initialize(Transform meteorTransform);
    public abstract Vector3 Move(float deltaTime, Vector2 vectorForward);
}