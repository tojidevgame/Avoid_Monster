using SuperMaxim.Messaging;
using UnityEngine;

public struct CoinCollectPayload
{

}

public class CoinItem : ItemBase
{
    [SerializeField] private ScoreDataSO scoreData;
    [Space(12)]
    [SerializeField] private BasePool effectPool;

    public override void TriggerItem()
    {
        if (isTrigger)
            return;

        scoreData.AddScore(((CoinConfig)itemConfig).Score);

        DestroyItem();
    }

    public override void DestroyItem(bool playDestroyEffect = true)
    {
        if (playDestroyEffect)
        {
            var destroyEffect = effectPool.Rent(((CoinConfig)itemConfig).EffectCoinDestroyKey);
            destroyEffect.transform.position = this.transform.position;
            destroyEffect.SetActive(true);
        }
        base.DestroyItem(playDestroyEffect);

        Messenger.Default.Publish<CoinCollectPayload>(new CoinCollectPayload());
    }
}
