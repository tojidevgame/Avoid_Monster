using SuperMaxim.Messaging;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private EnemyManagerDataSO enemyDataManagerSO;

    private void Start()
    {
        Messenger.Default.Subscribe<CoinCollectPayload>(CreateEnemy);
    }

    private void CreateEnemy(CoinCollectPayload payload)
    {
        enemyDataManagerSO.CreateEnemy();
    }


    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.P))
        {
            enemyDataManagerSO.CreateEnemy();
        }
#endif
    }

    private void OnDestroy()
    {
        Messenger.Default.Unsubscribe<CoinCollectPayload>(CreateEnemy);
    }
}
