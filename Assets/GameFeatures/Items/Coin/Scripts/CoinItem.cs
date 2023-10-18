using SuperMaxim.Messaging;
using UnityEngine;

public struct CoinCollectPayload
{
    public int AmountCoinCollect;
}

public class CoinItem : ItemBase
{
    [SerializeField] private ScoreDataSO scoreData;
    [Space(12)]
    [SerializeField] private BasePool effectPool;

    private void Awake()
    {
        Messenger.Default.Subscribe<GameOverPayload>(OnGameOver);
    }


    private void OnDestroy()
    {
        Messenger.Default.Unsubscribe<GameOverPayload>(OnGameOver);
    }

    private void OnGameOver(GameOverPayload gameOverPayload)
    {
        DestroyItem(false);
    }

    public override void TriggerItem()
    {
        if (isTrigger)
            return;
        int score = ((CoinConfig)itemConfig).Score;

        scoreData.AddScore(score);

        DestroyItem();

        Messenger.Default.Publish<CoinCollectPayload>(new CoinCollectPayload { AmountCoinCollect = score });
    }

    public override void DestroyItem(bool playDestroyEffect = true)
    {
        ConsoleLog.Log($"Destroy item: {playDestroyEffect}");
        if (playDestroyEffect)
        {
            var destroyEffect = effectPool.Rent(((CoinConfig)itemConfig).EffectCoinDestroyKey);
            destroyEffect.transform.position = this.transform.position;
            destroyEffect.SetActive(true);
        }
        base.DestroyItem(playDestroyEffect);
    }

    public override bool IsProtectItem()
    {
        return false;
    }
}
