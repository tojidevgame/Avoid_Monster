using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoSingleton<MapManager>
{
    [SerializeField] private Transform playerTrans;
    [SerializeField] private List<JumpPoint> posJumpPoint;

    [Space(10), Header("Line")]
    [SerializeField] private Transform[] posLine;
    public Vector2 GetBestJumpPoint(Vector2 curPos)
    {
        Vector2 result = posJumpPoint[0].transform.position;

        float minDistance = float.MaxValue;
        foreach (var jumpPoint in posJumpPoint)
        {
            float curDis = Vector2.Distance(jumpPoint.transform.position, curPos);
            float distanceToPlayer = Vector2.Distance(jumpPoint.transform.position, playerTrans.position);
            float totalDistance = curDis + distanceToPlayer;
            if (totalDistance < minDistance)
            {
                minDistance = totalDistance;
                result = jumpPoint.transform.position;
            }
        }
        return result;
    }
    public int CalculateLine(Vector2 curPos)
    {
        for (int i = 0; i < posLine.Length - 1; i++)
        {
            float curY = curPos.y;
            if (posLine[i].position.y <= curY && curY < posLine[i + 1].position.y)
            {
                return i;
            }
        }
        return 0;
    }
}
