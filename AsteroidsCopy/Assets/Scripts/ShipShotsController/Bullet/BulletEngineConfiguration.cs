using UnityEngine;

[CreateAssetMenu(menuName = "Configuration/Ship/Create BulletEngineConfiguration", fileName = "BulletEngine",
    order = 0)]
public class BulletEngineConfiguration : ScriptableObject
{
    [SerializeField] private float speed;

    public float Speed => speed;
}