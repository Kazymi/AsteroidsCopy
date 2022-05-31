using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLimiterInstaller : MonoBehaviour
{
    [SerializeField] private MapLimiterConfiguration mapLimiterConfiguration;
    [SerializeField] private Vector3 center;

    private void Awake()
    {
        var mapLimiter = new MapLimiter(mapLimiterConfiguration, center);
    }
}