using UnityEngine;

public class MeteorInstaller : TemporaryMonoPooled
{
    [SerializeField] private MeteorConfiguration meteorConfiguration;

    private MeteorEngine _meteorEngine;

    public override void Initialize()
    {
        base.Initialize();
        _meteorEngine ??= new MeteorEngine(meteorConfiguration);
        _meteorEngine.Initialize(transform);
        transform.position = _meteorEngine.Move(Time.deltaTime,transform.forward);
    }

    private void Update()
    {
        transform.position = _meteorEngine.Move(Time.deltaTime,transform.forward);
    }
}