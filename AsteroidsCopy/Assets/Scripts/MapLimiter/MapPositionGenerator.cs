using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MapPositionGenerator : IMapPositionGeneratorService
{
    private readonly MapLimiterConfiguration _mapLimiterConfiguration;
    private readonly Vector2 _center;

    public MapPositionGenerator(MapLimiterConfiguration mapLimiterConfiguration, Vector2 center)
    {
        _mapLimiterConfiguration = mapLimiterConfiguration;
        _center = center;
    }

    public Vector2 GetRandomPositionOutsideMap()
    {
        var randomPos = Random.insideUnitCircle.normalized;
        var returnValue = new Vector2(randomPos.x * _mapLimiterConfiguration.LimitX / 1.5f,
            randomPos.y * _mapLimiterConfiguration.LimitY / 1.5f);
        return returnValue;
    }

    public Vector2 GetRandomPositionInsideMap()
    {
        return new Vector2(
            _center.x + Random.Range(-_mapLimiterConfiguration.LimitX / 2, _mapLimiterConfiguration.LimitX / 2),
            _center.y + Random.Range(-_mapLimiterConfiguration.LimitY / 2, _mapLimiterConfiguration.LimitY / 2));
    }
}