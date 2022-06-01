using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLimiterInstaller : MonoBehaviour
{
    [SerializeField] private MapLimiterConfiguration mapLimiterConfiguration;
    [SerializeField] private Vector3 center;

    private IMapLimiterService _mapLimiterService;
    private IMapPositionGeneratorService _mapPositionGenerator;

    private void Awake()
    {
        _mapLimiterService = new MapLimiter(mapLimiterConfiguration, center);
        _mapPositionGenerator = new MapPositionGenerator(mapLimiterConfiguration, center);
    }

    private void OnEnable()
    {
        ServiceLocator.Subscribe<IMapLimiterService>(_mapLimiterService);
        ServiceLocator.Subscribe<IMapPositionGeneratorService>(_mapPositionGenerator);
    }

    private void OnDisable()
    {
        ServiceLocator.Unsubscribe<IMapLimiterService>();
        ServiceLocator.Unsubscribe<IMapPositionGeneratorService>();
    }
}