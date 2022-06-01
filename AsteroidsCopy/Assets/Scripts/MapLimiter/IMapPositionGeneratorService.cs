using UnityEngine;

public interface IMapPositionGeneratorService
{
    Vector2 GetRandomPositionOutsideMap();
    Vector2 GetRandomPositionInsideMap();
}