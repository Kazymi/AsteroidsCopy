using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class MeteorHealthInstaller : MonoBehaviour, IDamageable
{
    [SerializeField] private MeteorMovementController movementController;

    private MeteorHealth _meteorHealth;

    private void Start()
    {
        _meteorHealth = new MeteorHealth(movementController);
    }

    public void TakeDamage(DamageType damageType)
    {
        if (damageType == DamageType.ShipDamage)
        {
            _meteorHealth.TakeDamage();
        }
    }
}