using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RunConfig", menuName = "Avoid_Monster/Config/CharacterController/Run", order = 1)]
public class RunConfigs : ScriptableObject
{

    [HideInInspector] public Action onStartRun;
    [HideInInspector] public Action onRunning;
    [HideInInspector] public Action onStopRun;

    [SerializeField] private float speed = 400;
    [SerializeField] private float ratioSpeedWhenJump = 0.707f;

    private bool isFacingRight;
    public bool IsFacingRight { get { return isFacingRight; } set { isFacingRight = value; } }
    public float Speed { get { return speed; } }
    public float Speed_X_WhenJump { get { return ratioSpeedWhenJump * speed; } }

    public void ClearAllAction()
    {
        onStartRun = null;
        onRunning = null;
        onStopRun = null;
    }
}
