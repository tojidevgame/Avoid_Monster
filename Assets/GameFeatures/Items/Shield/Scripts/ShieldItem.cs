using UnityEngine;

public class ShieldItem : ItemBase
{
    [SerializeField] private ShieldConfig shieldConfig;
    [SerializeField] private GlobalData globalData;
    [SerializeField] private GameObjectPools itemPool;

    private bool isTrigger = false;
    private float countDownTime;


    private void Update()
    {
        if (!isTrigger)
            return;

        // TODO: Get player position to follow:
        transform.position = MapManager.Instance.PlayerTransform.position;


        countDownTime -= Time.deltaTime;
        if (countDownTime <= 0)
        {

            DestroyItem();
        }
    }


    public override void TriggerItem()
    {
        isTrigger = true;
        countDownTime = shieldConfig.TimeRemain;
    }

    protected override void DestroyItem()
    {
        ResetData();
        itemPool.Return(globalData.SHIELD_ITEM_KEY, this.gameObject);
    }

    protected override void ResetData()
    {
        isTrigger = false;
    }
}
