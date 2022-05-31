using UnityEngine;

public class ShipRotateController
{
    private float _currentRotation;
    private readonly IShipRotationConfiguration _shipRotationConfiguration;

    public ShipRotateController(IShipRotationConfiguration rotationConfiguration)
    {
        _shipRotationConfiguration = rotationConfiguration;
    }

    public Quaternion Rotate(float delta, float rotationAngle)
    {
        var newRotation =
            Mathf.Repeat(_currentRotation + (rotationAngle * _shipRotationConfiguration.RotationSpeed * delta), 360);
        var returnValue = Quaternion.Lerp(Quaternion.Euler(0, 0, _currentRotation), Quaternion.Euler(0, 0, newRotation),
            _shipRotationConfiguration.TurningTime);
        _currentRotation = newRotation;
        return returnValue;
    }
}