using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLimiterGizmos : MonoBehaviour
{
    [SerializeField] private MapLimiterConfiguration mapLimiterConfiguration;
    [SerializeField] private Vector3 center;

    private void OnDrawGizmosSelected()
    {
        if (mapLimiterConfiguration == null)
        {
            return;
        }

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(center,
            new Vector3(mapLimiterConfiguration.LimitX, mapLimiterConfiguration.LimitY, 0));
    }
}