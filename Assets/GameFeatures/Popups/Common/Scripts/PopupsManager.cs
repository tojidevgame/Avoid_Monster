using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using UnityEngine;

public enum PopupType
{
    StartGame,
    GameOver,
    Setting,
    Shop
}
public class PopupsManager : MonoSingleton<PopupsManager>
{
    [SerializeField] protected HolderDataPopups popupsDataHolder;
    [SerializeField] protected Transform parentCanvas;
    [SerializeField] protected GameObject blockRaycast;

    protected Dictionary<PopupType, PopupBase> popupsCreated;

    protected override void Awake()
    {
        popupsCreated = new Dictionary<PopupType, PopupBase>();
    }

    public async UniTask<PopupBase> ShowPopup(PopupType popupName, Func<UniTask> onCloseEvent = null)
    {
        try
        {
            // Check if popup is existed in Dictionary
            if (popupsCreated.ContainsKey(popupName))
            {
                PopupBase popupBase = popupsCreated[popupName];
                if(popupBase.gameObject.activeSelf)
                {
                    ConsoleLog.LogWarning($"Popup {popupName} has already opened");
                    return popupBase;
                }

                popupBase.PreSetupAction();

                popupBase.gameObject.SetActive(true);
                popupBase.RegisterOnCloseEvent(onCloseEvent);
                await UniTask.WaitUntil(() => popupBase.IsDoneShow);
                return popupBase;
            }

            // Create new Popup
            PopupData popupData = popupsDataHolder.GetPopupData(popupName);
            GameObject objPopup = Instantiate(popupData.Prefab, parentCanvas);

            PopupBase popup = objPopup.GetComponent<PopupBase>();
            popup.PreSetupAction();
            popup.RegisterOnCloseEvent(onCloseEvent);
            await UniTask.WaitUntil(() => popup.IsDoneShow);
            popupsCreated.Add(popupName, popup);  // Add popup to dictionary
            return popup;
        }
        catch (Exception ex)
        {
            ConsoleLog.LogError($"Popup {popupName} Show Error: " + ex.Message);
            return null;
        }
        finally
        {
            blockRaycast.SetActive(popupsCreated.Count > 0);
        }
    }

    public void ClosePopup(PopupType popupName)
    {
        try
        {
            popupsCreated.TryGetValue(popupName, out PopupBase popup);
            if (!popup.gameObject.activeSelf)
            {
                ConsoleLog.LogWarning($"Popup {popupName} has already closed");
                return;
            }
            popupsCreated.Remove(popupName);
            popup.ClosePopup();
        }
        catch (Exception ex)
        {
            ConsoleLog.LogError("Popup Close Error: " + ex.Message);
        }
    }

    public bool HasPopupOpened()
    {
        if(popupsCreated == null || popupsCreated.Count == 0)
            return false;
        foreach (var popup in popupsCreated.Values)
        {
            if (popup.gameObject.activeSelf)
                return true;
        }
        return false;
    }
}