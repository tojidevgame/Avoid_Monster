using BrunoMikoski.AnimationSequencer;
using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public class PopupBase : MonoBehaviour
{
    [Header("Animations")]
    [SerializeField] protected AnimationSequencerController animGoIn;
    [SerializeField] protected AnimationSequencerController animGoOut;

    [Tooltip("OnCloseEvent")]
    //protected Action onCloseEvent;

    protected Func<UniTask> onCloseEvent;

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
        animGoOut.Play(async () =>
        {
            await OnCloseEvent();
        });
    }

    protected void OnClosePopup()
    {
        Destroy(this.gameObject);
    }

    public virtual void RegisterOnCloseEvent(Func<UniTask> onCloseEvent)
    {
        this.onCloseEvent = onCloseEvent;
    }

    private async UniTask OnCloseEvent()
    {
        await UniTask.RunOnThreadPool(onCloseEvent);
        OnClosePopup();
    }
}
