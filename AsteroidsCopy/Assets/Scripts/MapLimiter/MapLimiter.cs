using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLimiter: MonoBehaviour, IMapLimiterService
{
    [SerializeField] private MapLimiterConfiguration mapLimiterConfiguration;
    [SerializeField] private Vector3 centerPosition;

    //value 1 = max, value 2 = min
    private Tuple<float, float> _currentXLimitation;
    private Tuple<float, float> _currentYLimitation;

    private void Awake()
    {
        Initialize();
    }

    private void OnEnable()
    {
        ServiceLocator.Subscribe<IMapLimiterService>(this);
    }

    private void OnDisable()
    {
        ServiceLocator.Unsubscribe<IMapLimiterService>();
    }

    public void Initialize()
    {
        _currentXLimitation = new Tuple<float, float>(centerPosition.x + mapLimiterConfiguration.LimitX / 2,
            centerPosition.x - mapLimiterConfiguration.LimitX / 2);
        _currentYLimitation = new Tuple<float, float>(centerPosition.y + mapLimiterConfiguration.LimitY / 2,
            centerPosition.y - mapLimiterConfiguration.LimitY / 2);
    }

    public Vector3 RecalculatePosition(Vector3 position)
    {
        var returnValue = position;
        if (position.x > _currentXLimitation.Item1) returnValue.x = _currentXLimitation.Item2;
        if (position.x < _currentXLimitation.Item2) returnValue.x = _currentXLimitation.Item1;
        if (position.y > _currentYLimitation.Item1) returnValue.y = _currentYLimitation.Item2;
        if (position.y < _currentYLimitation.Item2) returnValue.y = _currentYLimitation.Item1;
        return returnValue;
    }
}