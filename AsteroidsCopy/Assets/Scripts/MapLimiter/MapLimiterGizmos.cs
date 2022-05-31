using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLimiterGizmos : MonoBehaviour
{
    [SerializeField] private MapLimiterConfiguration mapLimiterConfiguration;

    private void OnDrawGizmosSelected()
    {
        if (mapLimiterConfiguration == null)
        {
            return;
        }

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position,
            new Vector3(mapLimiterConfiguration.LimitX, mapLimiterConfiguration.LimitY, 0));
    }
}