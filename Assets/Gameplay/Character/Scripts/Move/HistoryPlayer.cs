using System;
using UnityEngine;

public class HistoryPlayer : MonoBehaviour
{
    [SerializeField] private Vector2[] jumpPos = new Vector2[capacityHisPos];

    private const uint capacityHisPos = 500;

    private uint curIndexPlayer = 0;

    private void Start()
    {
        curIndexPlayer = 0;
    }

    public void AddPos(Vector2 jumpPoint)
    {
        if (curIndexPlayer >= capacityHisPos - 1)
            curIndexPlayer = 0;

        jumpPos[curIndexPlayer] = jumpPoint;
        curIndexPlayer++;
    }

    public Vector2 NextPos(ref uint curIndex)
    {
        curIndex++;
        if (curIndexPlayer >= capacityHisPos - 1)
            curIndexPlayer = 0;

        return jumpPos[curIndexPlayer];
    }

    public Vector2 CurPos(int curIndex)
    {
        try
        {
            return jumpPos[curIndex];
        }
        catch (Exception e)
        {
            return Vector2.zero;
        }
    }
}
