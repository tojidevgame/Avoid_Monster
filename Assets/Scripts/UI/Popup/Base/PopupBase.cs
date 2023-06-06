using UnityEngine;


public enum PopupType
{
    ShopPU,
    SettingPU,
}

public abstract class PopupBase : MonoBehaviour
{
    [SerializeField] protected float duration;

    protected virtual void Awake()
    {
        FadeIn();
    }

    public void ClosePU()
    {
        FadeOut();
        Destroy(gameObject, duration);
    }

    protected abstract void FadeIn();

    protected abstract void FadeOut();
}
