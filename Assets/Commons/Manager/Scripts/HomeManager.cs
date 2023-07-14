

using UnityEngine;

public class HomeManager : MonoSingleton<HomeManager>
{
    void Start()
    {
        //PopupsManager.Instance.ShowPopup(PopupType.Main);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            PopupsManager.Instance.ShowPopup(PopupType.Main);
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            PopupsManager.Instance.ClosePopup(PopupType.Main);
        }
    }
}
