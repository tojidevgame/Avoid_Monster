using UnityEngine;

public class EnemyDataManagement : MonoBehaviour
{
    [SerializeField] protected RunConfigs runData;
    [SerializeField] protected JumpConfigs jumpData;
    [SerializeField] protected DashConfigs dashData;

    public RunConfigs RunData { get { return runData; } }
    public JumpConfigs JumpData { get { return jumpData; } }
    public DashConfigs DashData { get { return dashData; } }

    private bool isDoneInit = false;
    public bool IsDoneInit
    {
        get { return isDoneInit; }
    }
    private void Awake()
    {
        isDoneInit = false;

        runData = ScriptableObject.CreateInstance<RunConfigs>();
        jumpData = ScriptableObject.CreateInstance<JumpConfigs>();
        dashData = ScriptableObject.CreateInstance<DashConfigs>();

        isDoneInit = true;
    }
}
