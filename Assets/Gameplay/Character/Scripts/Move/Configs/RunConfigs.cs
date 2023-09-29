using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RunConfig", menuName = "Avoid_Monster/Config/CharacterController/Run", order = 1)]
public class RunConfigs : ScriptableObject
{

    [HideInInspector] public Action onStartRun;
    [HideInInspector] public Action onStopRun;

    [SerializeField] private float speed = 400;

    private bool isFacingRight;
    public bool IsFacingRight { get { return isFacingRight; } set { isFacingRight = value; } }
    public float Speed
    { 
        get { return speed; }
        set { speed = value; }
    }

    public void ClearAllAction()
    {
        onStartRun = null;
        onStopRun = null;
    }
}
