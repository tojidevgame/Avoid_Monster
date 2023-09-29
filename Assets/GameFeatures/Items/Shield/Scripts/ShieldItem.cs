using SuperMaxim.Messaging;
using UnityEngine;

public class ShieldItem : ItemBase
{
    [SerializeField] private PlayerDataSO playerDataSO;

    [Space(12)]
    [SerializeField] private GameObject shieldIconRender;
    [SerializeField] private ParticleSystem shieldEffect;

    [Space(12)]
    [SerializeField] private BasePool effectPool;



    private float countDownTimeRemain;


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

        // TODO: Get player position to follow: 
        // Co the thay doi bang cach dua no vao item holder
        gameObject.transform.position = playerDataSO.PlayerTransform.position;


        countDownTimeRemain -= Time.deltaTime;
        if (countDownTimeRemain <= 0)
        {
            DestroyItem();
        }
    }

    public override void SetupData(ItemBoundPosition itemBound)
    {
        base.SetupData(itemBound);
        countDownTimeExist = itemConfig.TimeExists;
        countDownTimeRemain = itemConfig.TimeRemain;

        shieldIconRender.SetActive(true);
        shieldEffect.gameObject.SetActive(false);
        anim?.PlayAnim();
    }

    public override void TriggerItem()
    {
        if (isTrigger)
            return;
        anim?.StopAnim();
        isTrigger = true;

        shieldIconRender.SetActive(false);
        shieldEffect.gameObject.SetActive(true);
        shieldEffect.Play();
    }

    public override void DestroyItem(bool playDestroyEffect = true)
    {
        if (playDestroyEffect)
        {
            var destroyEffect = effectPool.Rent(((ShieldConfig)itemConfig).EffectShieldDestroyKey);
            destroyEffect.transform.position = this.transform.position;
            destroyEffect.SetActive(true);
        }
        anim?.StopAnim();
        base.DestroyItem();
        Messenger.Default.Publish<DestroyItem>(new DestroyItem() { ItemKey = itemConfig.ItemKey });
    }

    public override bool IsProtectItem()
    {
        return isTrigger;
    }
}
