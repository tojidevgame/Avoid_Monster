using UnityEngine;

[CreateAssetMenu(fileName = "PopupData", menuName = "ScriptableObjects/Popup/PopupData", order = 1)]
public class PopupData : ScriptableObject
{
    [SerializeField] protected PopupType popupName;
    [SerializeField] protected GameObject prefab;

    public PopupType PopupName
    {
        get { return popupName; }
    }

    public GameObject Prefab
    {
        get { return prefab; }
    }
}
