using UnityEngine;

[CreateAssetMenu(fileName = "PlayerDataSO", menuName = "Avoid_Monster/Runtime Data/PlayerData")]
public class PlayerDataSO : ScriptableObject
{
    private PlayerInfo playerInfo;
    private HistoryPlayerPosition historyPos;

    public Transform PlayerTransform => playerInfo.transform;

    public void InitData(PlayerInfo playerInfo)
    {
        this.playerInfo = playerInfo;
        historyPos = new HistoryPlayerPosition(playerInfo.transform.position);
    }

    public void AddNewPosOfPlayer()
    {
        historyPos.Add(playerInfo.transform.position);
    }

    public int CurrentPlayerIndex()
    {
        return historyPos.CurPlayerIndex;
    }

    public Vector2 PosAtIndex(ref int index)
    {
        return historyPos.PosAtIndex(ref index);
    }

    public Vector2 PosAtNextIndexOf(int curIndex)
    {
        return historyPos.PosAtNextIndexOf(curIndex);
    }

    public void ClampEnemyIndex(ref int curIndex)
    {
        if (curIndex < 0)
            curIndex = historyPos.Capacity + curIndex;
    }
}
