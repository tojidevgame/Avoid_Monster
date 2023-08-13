using UnityEngine;

public class MapManager : MonoSingleton<MapManager>
{
    [SerializeField] private PlayerInfo playerInfo;
    [SerializeField] private float minDistanceToAddPos = 0.2f;

    private HistoryPlayerPosition historyPos;

    public Transform PlayerTransform { get { return playerInfo.transform; } }

    protected void Start()
    {
        base.Awake();
        historyPos = new HistoryPlayerPosition(minDistanceToAddPos, playerInfo.transform.position);
    }

    private void FixedUpdate()
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
        if(curIndex < 0)
            curIndex = historyPos.Capacity + curIndex;
    }
}
