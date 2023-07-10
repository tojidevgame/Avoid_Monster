using BrunoMikoski.AnimationSequencer;
using System;
using UnityEngine;

public class PopupBase : MonoBehaviour
{
    [Header("Animations")]
    [SerializeField] protected AnimationSequencerController animGoIn;
    [SerializeField] protected AnimationSequencerController animGoOut;

    [Tooltip("Miliseconds")]
    protected Action onCloseEvent;

    protected void OnEnable()
    {
        animGoIn.Play(OnShowPopup);
    }

    protected virtual void OnShowPopup()
    {
    }

    public virtual void ClosePopup()
    {
        onCloseEvent?.Invoke();
        animGoOut.Play(OnClosePopup);
    }

    protected void OnClosePopup()
    {
        gameObject.SetActive(false);
    }

    public virtual void RegisterOnCloseEvent(Action onCloseEvent)
    {
        this.onCloseEvent = onCloseEvent;
    }
}
