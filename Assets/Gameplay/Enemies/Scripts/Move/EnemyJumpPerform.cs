using Cysharp.Threading.Tasks;
using UnityEngine;
using static UnityEngine.Mesh;

[RequireComponent(typeof(EnemyDataManagement))]
public class EnemyJumpPerform : JumpPerform
{
    EnemyDataManagement dataManagement;

    private bool isDoneLoadData = false;
    protected override async void Awake()
    {
        isDoneLoadData = false;

        EnemyDataManagement dataManagement = GetComponent<EnemyDataManagement>();
        dataManagement = GetComponent<EnemyDataManagement>();
        if (dataManagement == null)
        {
            dataManagement = gameObject.AddComponent<EnemyDataManagement>();
        }

        await UniTask.WaitUntil(() => dataManagement.IsDoneInit);

        base.Awake();

        jumpData = dataManagement.JumpData;

        isDoneLoadData = true;
    }

    protected override async void Start()
    {
        await UniTask.WaitUntil(() => isDoneLoadData);
        base.Start();
    }

    protected override void Update()
    {
        if(isDoneLoadData)
        {
            base.Update();
        }
    }
}
