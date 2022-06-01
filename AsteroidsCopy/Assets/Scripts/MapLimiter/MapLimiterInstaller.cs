using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLimiterInstaller : MonoBehaviour
{
    [SerializeField] private MapLimiterConfiguration mapLimiterConfiguration;
    [SerializeField] private Vector3 center;

    private IMapLimiterService _mapLimiterService;
    private void Awake()
    {
        _mapLimiterService = new MapLimiter(mapLimiterConfiguration, center);
    }

    private void OnEnable()
    {
        ServiceLocator.Subscribe<IMapLimiterService>(_mapLimiterService);
    }

    private void OnDisable()
    {
        ServiceLocator.Unsubscribe<IMapLimiterService>();
    }
}