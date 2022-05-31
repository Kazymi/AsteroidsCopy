using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLimiter : IMapLimiterService
{
    private readonly MapLimiterConfiguration _mapLimiterConfiguration;
    private readonly Vector3 _centerPosition;

    //value 1 = max, value 2 = min
    private Tuple<float, float> _currentXLimitation;
    private Tuple<float, float> _currentYLimitation;

    public MapLimiter(MapLimiterConfiguration mapLimiterConfiguration, Vector3 center)
    {
        _mapLimiterConfiguration = mapLimiterConfiguration;
        _centerPosition = center;
        Initialize();
        ServiceLocator.Subscribe<IMapLimiterService>(this);
    }

    ~MapLimiter()
    {
        ServiceLocator.Unsubscribe<IMapLimiterService>();
    }

    private void Initialize()
    {
        _currentXLimitation = new Tuple<float, float>(_centerPosition.x + _mapLimiterConfiguration.LimitX / 2,
            _centerPosition.x - _mapLimiterConfiguration.LimitX / 2);
        _currentYLimitation = new Tuple<float, float>(_centerPosition.y + _mapLimiterConfiguration.LimitY / 2,
            _centerPosition.y - _mapLimiterConfiguration.LimitY / 2);
    }

    public Vector3 RecalculatePosition(Vector3 position)
    {
        var returnValue = position;
        if (position.x > _currentXLimitation.Item1)
        {
            returnValue.x = _currentXLimitation.Item2;
        }

        if (position.x < _currentXLimitation.Item2)
        {
            returnValue.x = _currentXLimitation.Item1;
        }

        if (position.y > _currentYLimitation.Item1)
        {
            returnValue.y = _currentYLimitation.Item2;
        }

        if (position.y < _currentYLimitation.Item2)
        {
            returnValue.y = _currentYLimitation.Item1;
        }
        return returnValue;
    }
}