using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLimiterController : MonoBehaviour
{
   [SerializeField] private Transform objectToLimit;

   private IMapLimiterService _limiterService;

   private void Start()
   {
      _limiterService = ServiceLocator.GetService<IMapLimiterService>();
   }

   private void LateUpdate()
   {
     objectToLimit.position = _limiterService.RecalculatePosition(objectToLimit.position);
   }
}
