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
            PopupsManager.Instance.ClosePopup(PopupType.StartGame);
        });
    }
}
