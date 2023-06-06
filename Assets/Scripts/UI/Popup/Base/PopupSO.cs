using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "UI/Popup/PopupConfig", order = 1)]
public class PopupSO : ScriptableObject
{
    [Serializable]
    private class GroupPopup
    {
        public GameObject Popup;
        public PopupType PopupType;
    }

    [SerializeField] private List<GroupPopup> popups = new List<GroupPopup>();

    public GameObject GetPopupByType(PopupType puType)
    {
        int index = popups.FindIndex(x => x.PopupType == puType);
        CommonLog.LogInfo(index.ToString());

        if (index != -1)
            return popups[index].Popup;
        return null;
    }
}

