using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

[RequireComponent(typeof(EnemyDataManagement))]
public class EnemyRunPerform : RunPerform
{
    EnemyDataManagement dataManagement;

    private bool isDoneLoadData = false;
    protected override async void Awake()
    {
        isDoneLoadData = false;

        dataManagement = GetComponent<EnemyDataManagement>();
        if(dataManagement == null)
        {
            dataManagement = gameObject.AddComponent<EnemyDataManagement>();
        }
        await UniTask.WaitUntil(() => dataManagement.IsDoneInit);

        base.Awake();

        runData = dataManagement.RunData;
        jumpData = dataManagement.JumpData;
        dashData = dataManagement.DashData;

        isDoneLoadData = true;
    }

    protected override void FixedUpdate()
    {
        if (isDoneLoadData)
        {
            base.FixedUpdate();
        }
    }

    protected override void Update()
    {
        if (isDoneLoadData)
        {
            base.Update();
        }
    }
}
