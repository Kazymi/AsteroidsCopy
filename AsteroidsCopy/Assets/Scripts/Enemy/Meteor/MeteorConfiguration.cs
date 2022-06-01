using UnityEngine;

[CreateAssetMenu(menuName = "Configurations/Enemy/Create MeteorConfiguration", fileName = "MeteorConfiguration", order = 0)]
public class MeteorConfiguration : ScriptableObject
{
    [SerializeField] private float meteorSpeed;

    public float MeteorSpeed => meteorSpeed;
}