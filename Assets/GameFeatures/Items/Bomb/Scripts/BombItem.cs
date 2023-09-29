using SuperMaxim.Messaging;
using UnityEngine;

public class BombItem : ItemBase
{
    [Space(12)]
    [SerializeField] private BasePool effectPool;
    private float countDownTimeExplode;

    public override void TriggerItem()
    {
        if(isTrigger)
            return;
        anim?.StopAnim();
        isTrigger = true;
        countDownTimeExplode = ((BombConfig)itemConfig).TimeToExpode;
    }


    private void Update()
    {
        countDownTimeExist -= Time.deltaTime;

        if (!isTrigger)
        {
            if(countDownTimeExist <= 0)
            {
                DestroyItem();
            }
            return;
        }

        countDownTimeExplode -= Time.deltaTime;
        if(countDownTimeExplode <= 0)
        {
            Explode();

            DestroyItem();
        }
    }

    private void Explode()
    {
        // Find what enemy will be kill
        Physics2D.OverlapCircle(transform.position, ((BombConfig)itemConfig).RangeExplode, ((BombConfig)itemConfig).LayerImpact);

        // Trigger effect explode
        ConsoleLog.Log("Bomb Explore");
    }

    public override void DestroyItem(bool playDestroyEffect = true)
    {
        // TODO: Play effect
        anim?.StopAnim();
        base.DestroyItem();
        Messenger.Default.Publish<DestroyItem>(new DestroyItem() { ItemKey = itemConfig.ItemKey });
    }

    public override bool IsProtectItem()
    {
        return false;
    }
}
