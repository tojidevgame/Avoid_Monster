using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public class EnemyDataManagement : MonoBehaviour
{
    [Header("Origin")]
    [SerializeField] private RunConfigs originalRunConfig;
    [SerializeField] private JumpConfigs originalJumpConfig;
    [SerializeField] private DashConfigs originalDashConfig;

    protected RunConfigs runData;
    protected JumpConfigs jumpData;
    protected DashConfigs dashData;

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

        runData = Instantiate(originalRunConfig) as RunConfigs;
        jumpData = Instantiate(originalJumpConfig) as JumpConfigs;
        dashData = Instantiate(originalDashConfig) as DashConfigs;

        isDoneInit = true;
    }

    public async void RegisterOnStartJump(Action onStartJumpAction)
    {
        await UniTask.WaitUntil(() => jumpData != null);
        jumpData.onStartJump += onStartJumpAction;
    }

    private void OnDestroy()
    {
        jumpData.ClearAllAction();
        runData.ClearAllAction();
    }
}
