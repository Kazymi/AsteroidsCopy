using System;

public interface IWeaponInput
{
    event Action callShot;
    event Action callLaser;
}