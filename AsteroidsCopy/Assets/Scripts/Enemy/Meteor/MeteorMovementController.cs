using UnityEngine;

public class MeteorMovementController : TemporaryMonoPooled
{
    [SerializeField] private MeteorConfiguration meteorConfiguration;
    [SerializeField] private MeteorType meteorType;
    private MeteorEngine _meteorEngine;

    public Vector3 MeteorPosition => transform.position;

    private void Update()
    {
        transform.position = _meteorEngine.Move(Time.deltaTime, transform.forward);
    }
    
    public override void Initialize()
    {
        base.Initialize();
        if (_meteorEngine == null)
        {
            InitializeEngine();
        }

        _meteorEngine.Initialize(transform);
    }

    private void InitializeEngine()
    {
        switch (meteorType)
        {
            case MeteorType.BigMeteor:
                _meteorEngine = new BigMeteorEngine(meteorConfiguration);
                break;
            case MeteorType.SmallMeteor:
                _meteorEngine = new SmallMeteorEngine(meteorConfiguration);
                break;
        }
    }
}