using Cysharp.Threading.Tasks;
using SuperMaxim.Messaging;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private ItemConfigBase[] itemsConfigBase;
    [SerializeField] private CoinConfig[] coinConfigs;
    [SerializeField] private BasePool itemsPool;
    [SerializeField] private BasePool coinPool;
    [SerializeField] private LevelDataSO levelDataSO;


    [Header("Data")]
    [SerializeField] private MapDataSO mapDataSO;

    private int curAmountItem;
    private float countDownTimeGenItem;

    private bool isGameOver = false;

    private void Awake()
    {
        Messenger.Default.Subscribe<GameOverPayload>(OnGameOver);
    }



    private async void Start()
    {
        isGameOver = false;

        countDownTimeGenItem = Random.Range(levelDataSO.CurrentDiff.MinTimeToGenItem, levelDataSO.CurrentDiff.MinTimeToGenItem);
        Messenger.Default.Subscribe<DestroyItem>(OnDestroyItem);
        Messenger.Default.Subscribe<CoinCollectPayload>(OnCoinCollected);

        await UniTask.WaitUntil(() => mapDataSO.IsDoneInit);
        GenerateCoin();
    }

    private void Update()
    {
        if (isGameOver)
            return;

        countDownTimeGenItem -= Time.deltaTime;
        if (countDownTimeGenItem <= 0 && curAmountItem < levelDataSO.CurrentDiff.MaxAmountItem)
        {
            GenerateItem();

            countDownTimeGenItem = Random.Range(levelDataSO.CurrentDiff.MinTimeToGenItem, levelDataSO.CurrentDiff.MinTimeToGenItem);
        }
    }

    private void OnDestroy()
    {
        Messenger.Default.Unsubscribe<DestroyItem>(OnDestroyItem);
        Messenger.Default.Unsubscribe<CoinCollectPayload>(OnCoinCollected);
    }


    public void GenerateItem()
    {
        int amountItemToGen = Random.Range(levelDataSO.CurrentDiff.MinItemInOneGen, levelDataSO.CurrentDiff.MaxItemInOneGen + 1);
        for (int i = 0; i < amountItemToGen; i++)
        {
            RandomItem();
            curAmountItem++;
        }
    }

    private void RandomItem()
    {
        int index = Random.Range(0, itemsConfigBase.Length);
        ItemBase item = itemsPool.Rent(itemsConfigBase[index].ItemKey).GetComponent<ItemBase>();

        ItemBoundPosition boundPosition = mapDataSO.RandomItemBoundPosition();
        if (boundPosition == null)
            itemsPool.Return(item.ItemConfig.ItemKey, item.gameObject);

        //Set position for item
        item.transform.position = boundPosition.RandomPosition();

        item.SetupData(boundPosition);

        // Finally, active item
        item.gameObject.SetActive(true);
    }

    private void OnDestroyItem(DestroyItem payload)
    {
        curAmountItem--;
    }

    private void OnCoinCollected(CoinCollectPayload payload)
    {
        GenerateCoin();
    }

    private void GenerateCoin()
    {
        if (isGameOver)
            return;
        // TODO: Check do kho co cho phep Generate Coin Special khong

        // Tam thoi random theo Rate
        int totalRate = 0;
        foreach(var coinConfig in coinConfigs)
        {
            totalRate += coinConfig.RateAppear;
        }


        int rate = Random.Range(1, totalRate + 1);

        for (int i = 0; i < coinConfigs.Length; i++)
        {
            if(rate <= coinConfigs[i].RateAppear)
            {
                ItemBase item = coinPool.Rent(coinConfigs[i].ItemKey).GetComponent<ItemBase>();
                ItemBoundPosition boundPosition = mapDataSO.RandomItemBoundPosition();
                if(boundPosition == null)
                    itemsPool.Return(item.ItemConfig.ItemKey, item.gameObject);

                //Set position for item
                item.transform.position = boundPosition.RandomPosition();

                item.SetupData(boundPosition);

                // Finally, active item
                item.gameObject.SetActive(true);
                break;
            }

            rate -= coinConfigs[i].RateAppear;
        }
    }

    private void OnGameOver(GameOverPayload gameOverPayload)
    {
        isGameOver = true;
    }
}
