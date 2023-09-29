using SuperMaxim.Messaging;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private LevelDataSO levelDataSO;

    private void Start()
    {
        levelDataSO.ResetLevel();
        Messenger.Default.Subscribe<CoinCollectPayload>(TryUpdateLevel);
    }



    private void TryUpdateLevel(CoinCollectPayload payload)
    {
        levelDataSO.TryUpdateLevel();
    }

    private void OnDestroy()
    {
        Messenger.Default.Unsubscribe<CoinCollectPayload>(TryUpdateLevel);
    }
}
