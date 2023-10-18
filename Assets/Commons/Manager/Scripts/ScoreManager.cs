using SuperMaxim.Messaging;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private ScoreDataSO scoreDataSO;

    private void Start()
    {
        scoreDataSO.ResetScore();
        scoreDataSO.HighScore = PlayerPrefs.GetInt("HighScore", 0);

        Messenger.Default.Subscribe<StartGamePayload>(ResetScore);
    }

    private void ResetScore(StartGamePayload payload)
    {
        scoreDataSO.ResetScore();
    }

    private void OnDestroy()
    {
        Messenger.Default.Unsubscribe<StartGamePayload>(ResetScore);
    }
}
