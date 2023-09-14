using UnityEngine;

public enum TypeActiveItem
{
    REMAIN,
    USEONETIME
}
public abstract class ItemConfigBase : ScriptableObject
{
    [SerializeField] private string itemKey;
    [SerializeField] private float timeExists;
    [SerializeField] private float timeRemain = 5f;
    [SerializeField] private TypeActiveItem typeActiveItem;

    public float TimeRemain
    {
        get { return timeRemain; }
    }
    public float TimeExists => timeExists;
    public string ItemKey => itemKey;
    public TypeActiveItem TypeActiveItem => typeActiveItem;
}
