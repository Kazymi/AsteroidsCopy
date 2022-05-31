using UnityEngine;

[CreateAssetMenu(menuName = "Configuration/Ship/Create ShipMovementConfiguration",
    fileName = "ShipMovementConfiguration", order = 0)]
public class ShipMovementConfiguration : ScriptableObject, IShipRotationConfiguration, IMovementConfiguration
{
    [SerializeField] private float speed;
    [SerializeField] private float maxAcceleration;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float turningTime;
    [SerializeField] private float stopTime;

    public float Speed => speed;

    public float MaxAcceleration => maxAcceleration;

    public float TurningTime => turningTime;
    public float RotationSpeed => rotationSpeed;
    public float StopTime => stopTime;
}