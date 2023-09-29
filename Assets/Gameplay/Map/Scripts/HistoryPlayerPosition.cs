using System;
using UnityEngine;


public class HistoryPlayerPosition
{
    private int capacity = 3000;
    private Vector2[] historyPos;

    private int curPlayerIndex = 0;

    public int CurPlayerIndex { get => curPlayerIndex; }
    public int Capacity { get { return capacity; } }

    public HistoryPlayerPosition(Vector2 playerPos)
    {
        historyPos = new Vector2[capacity];
        curPlayerIndex = 0;
        historyPos[0] = playerPos;
    }

    public void Add(Vector2 newPos)
    {
        bool canAdd = historyPos[curPlayerIndex] != newPos;
        if (!canAdd)
            return;
        curPlayerIndex++;
        if (curPlayerIndex >= capacity)
            curPlayerIndex = 0;

        historyPos[curPlayerIndex] = newPos;
    }

    public Vector2 PosAtIndex(ref int index)
    {
        Vector2 result = Vector2.zero;
        try
        {
            result = historyPos[index];
            index++;
            if (index >= capacity)
                index = 0;
        }
        catch (Exception e)
        {
            ConsoleLog.LogError(e.Message);
        }
        return result;
    }

    public Vector2 PosAtNextIndexOf(int curIndex)
    {
        try
        {
            if(curIndex < capacity - 1)
                return historyPos[curIndex + 1];
            return historyPos[0];
        }
        catch (Exception ex)
        {
            ConsoleLog.LogError(ex.Message);
        }

        return Vector2.zero;
    }
}
