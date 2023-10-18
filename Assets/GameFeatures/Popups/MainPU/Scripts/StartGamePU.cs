using SuperMaxim.Messaging;
using UnityEngine;
using UnityEngine.UI;

public struct StartGamePayload
{

}

public class StartGamePU : PopupBase
{
    [SerializeField] private Button btnPlay;

    private void Start()
    {
        btnPlay.onClick.AddListener(() =>
        {
            PopupsManager.Instance.ClosePopup(PopupType.StartGame, () =>
            {
                Messenger.Default.Publish<StartGamePayload>(new StartGamePayload());
            });
        });
    }

    private void OnDestroy()
    {
        btnPlay.onClick.RemoveAllListeners();
    }
}
