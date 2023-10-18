using BrunoMikoski.AnimationSequencer;
using Cysharp.Threading.Tasks;
using System;
using Unity.VisualScripting;
using UnityEngine;

public class PopupBase : MonoBehaviour
{
    [Header("Animations")]
    [SerializeField] protected AnimationSequencerController animGoIn;
    [SerializeField] protected AnimationSequencerController animGoOut;

    [Tooltip("OnCloseEvent")]
    //protected Action onCloseEvent;

    protected Action onCloseEvent;

    private bool isDoneShow = false;
    public bool IsDoneShow => isDoneShow;
    protected void OnEnable()
    {
        ConsoleLog.LogError("Play anim");
        animGoIn.Play(OnShowPopup);
    }

    public virtual void PreSetupAction()
    {

    }

    protected virtual void OnShowPopup()
    {
        isDoneShow = true;
    }

    public virtual void ClosePopup()
    {
        animGoOut.Play(() =>
        {
            OnCloseEvent();
        });
    }

    protected void OnClosePopup()
    {
        Destroy(this.gameObject);
    }

    public virtual void RegisterOnCloseEvent(Action onCloseEvent)
    {
        this.onCloseEvent = onCloseEvent;
    }

    private void OnCloseEvent()
    {
        onCloseEvent?.Invoke();
        OnClosePopup();
    }
}
