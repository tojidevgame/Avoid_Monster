using UnityEngine;

[CreateAssetMenu(fileName = "HolderDataPopups", menuName = "ScriptableObjects/Popup/HolderDataPopups", order = 1)]
public class HolderDataPopups : ScriptableObject
{
    [SerializeField] protected PopupData[] popupBases;

    public PopupData GetPopupData(PopupType popupName)
    {
        for (int i = 0; i < popupBases.Length; i++)
        {
            if (popupBases[i].PopupName == popupName)
                return popupBases[i];
        }
        return null;
    }
}