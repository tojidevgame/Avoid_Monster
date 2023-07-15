using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public class HistoryPlayer : MonoSingleton<HistoryPlayer>
{
    [SerializeField] private JumpConfigs jumpData;
    private Vector2[] jumpPos = new Vector2[capacityHisPos];

    private const uint capacityHisPos = 500;

    private uint curIndexPlayer = 0;

    private void Awake()
    {
        AddPos(transform.position);
    }
    private void Start()
    {
        curIndexPlayer = 0;
        jumpData.onStartJump += AddJumpPoint;
    }
    public void AddJumpPoint()
    {
        AddPos(transform.position);
    }
    public void AddPos(Vector2 jumpPoint)
    {
        if (curIndexPlayer >= capacityHisPos - 1)
            curIndexPlayer = 0;

        jumpPos[curIndexPlayer] = jumpPoint;
        curIndexPlayer++;
    }

    public Vector2 NextPosIncreaseIndex(ref uint curIndex)
    {
        curIndex++;
        if (curIndex >= capacityHisPos - 1)
            curIndex = 0;

        return jumpPos[curIndex];
    }

    public Vector2 CurPos(uint curIndex)
    {
        try
        {
            return jumpPos[curIndex];
        }
        catch (Exception e)
        {
            ConsoleLog.LogError("Get Cur Pos: " + e);
            return Vector2.zero;
        }
    }

    public Vector2 NextPosOfCurrent(uint curIndex)
    {
        curIndex++;
        if (curIndex >= capacityHisPos - 1)
            curIndex = 0;

        return jumpPos[curIndex];
    }
}
