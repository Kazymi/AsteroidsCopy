using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D),typeof(Rigidbody2D))]
public class DamageDealerInstaller : MonoBehaviour
{
    [SerializeField] private DamageType damageType;

    private DamageDealer _damageDealer;

    private void Start()
    {
        _damageDealer = new DamageDealer(damageType);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _damageDealer.TryToDamage(other.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("1");
        _damageDealer.TryToDamage(other.gameObject);
    }
}