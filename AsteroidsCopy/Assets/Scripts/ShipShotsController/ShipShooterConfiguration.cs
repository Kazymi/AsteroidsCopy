using UnityEngine;

[CreateAssetMenu(menuName = "Configurations/Ship/Create ShipShooterConfiguration", fileName = "ShipShooterConfiguration", order = 0)]
public class ShipShooterConfiguration : ScriptableObject
{
    [SerializeField] private float fireRate;
    [SerializeField] private float laserCoolDown;

    public float LaserCoolDown => laserCoolDown;

    public float FireRate => fireRate;
}