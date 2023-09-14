using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private PlayerDataSO playerDataSO;
    [SerializeField] private MapDataSO mapDataSO;

    [Space(12)]
    [SerializeField] private PlayerInfo playerInfo;

    [Space(12)]
    [SerializeField] private List<ItemBoundPosition> itemPositionList;

    public Transform PlayerTransform { get { return playerInfo.transform; } }

    protected void Start()
    {
        playerDataSO.InitData(playerInfo);
        mapDataSO.InitData(itemPositionList);
    }

    private void FixedUpdate()
    {
        playerDataSO.AddNewPosOfPlayer();
    }
}
