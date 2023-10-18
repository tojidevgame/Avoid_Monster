using DG.Tweening;
using SuperMaxim.Messaging;
using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtScore;
    [SerializeField] private Vector3 scale;
    [SerializeField] private float durationPunch;

    private int currentScore;

    private void Awake()
    {
        Messenger.Default.Subscribe<CoinCollectPayload>(UpdateScore);
        Messenger.Default.Subscribe<StartGamePayload>(ResetScore);
    }

    private void ResetScore(StartGamePayload payload)
    {
        currentScore = 0;
        txtScore.SetText(currentScore.ToString());
    }

    private void UpdateScore(CoinCollectPayload payload)
    {
        currentScore += payload.AmountCoinCollect;
        txtScore.SetText(currentScore.ToString());

        transform.DOPunchScale(scale, durationPunch);
    }

    private void OnDestroy()
    {
        Messenger.Default.Unsubscribe<CoinCollectPayload>(UpdateScore);
        Messenger.Default.Unsubscribe<StartGamePayload>(ResetScore);
    }
}
