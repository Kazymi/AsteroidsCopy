using UnityEngine;

public class DamageDealer
{
    private readonly DamageType _damageType;

    public DamageDealer(DamageType damageType)
    {
        _damageType = damageType;
    }

    public void TryToDamage(GameObject objectForDamage)
    {
        var damageable = objectForDamage.gameObject.GetComponent<IDamageable>();
        damageable?.TakeDamage(_damageType);
    }
}