using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "MapDataSO", menuName = "Avoid_Monster/Runtime Data/MapDataSO")]
public class MapDataSO : ScriptableObject
{
    private List<ItemBoundPosition> itemPositionList;

    public bool IsDoneInit = false;

    public void InitData(List<ItemBoundPosition> itemPositionList)
    {
        this.itemPositionList = itemPositionList;
        IsDoneInit = true;
    }

    public ItemBoundPosition RandomItemBoundPosition()
    {
        int index = Random.Range(0, itemPositionList.Count);   
        var itemPosition = itemPositionList[index];
        itemPositionList.RemoveAt(index);
        return itemPosition;
    }

    public void ReturnToPool(ItemBoundPosition position)
    {
        itemPositionList.Add(position);
    }
}
