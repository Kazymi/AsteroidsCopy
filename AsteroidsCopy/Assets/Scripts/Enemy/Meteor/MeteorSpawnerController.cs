using UnityEngine;

public class MeteorSpawnerController : MonoBehaviour
{
    [SerializeField] private float spawnInterval;

    private IUpdatable _meteorSpawner;

    private void Start()
    {
        _meteorSpawner = new MeteorSpawner(spawnInterval);
    }

    private void Update()
    {
        _meteorSpawner.Update(Time.deltaTime);
    }
}