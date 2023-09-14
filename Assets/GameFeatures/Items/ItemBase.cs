using SuperMaxim.Messaging;
using UnityEngine;

public struct DestroyItem
{
    public string ItemKey;
}

public abstract class ItemBase : MonoBehaviour
{
    [SerializeField] protected ItemConfigBase itemConfig;
    [Space(12)]
    [SerializeField] protected BasePool itemPoolSO;
    [Space(12)]
    [SerializeField] protected AnimBase anim;

    protected ItemBoundPosition itemBoundPosition;
    protected float countDownTimeExist;

    protected bool isTrigger = false;
    public bool IsTrigger => isTrigger;

    public ItemConfigBase ItemConfig => itemConfig;

    public virtual void SetupData(ItemBoundPosition itemBound)
    {
        this.itemBoundPosition = itemBound;
    }
    public abstract void TriggerItem();
    public virtual void DestroyItem(bool playDestroyEffect = true)
    {
        ResetData();
        itemBoundPosition.ReturnToPool();
        itemPoolSO.Return(itemConfig.ItemKey, this.gameObject);
    }
    protected virtual void ResetData()
    {
        isTrigger = false;
    }
}
