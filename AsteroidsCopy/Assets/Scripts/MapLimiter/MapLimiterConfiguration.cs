using UnityEngine;

[CreateAssetMenu(menuName = "Configurations/MapLimiterConfiguration", fileName = "MapLimiterConfiguration", order = 0)]
public class MapLimiterConfiguration : ScriptableObject
{
    [SerializeField] private float limitX;
    [SerializeField] private float limitY;

    public float LimitX => limitX;

    public float LimitY => limitY;
}