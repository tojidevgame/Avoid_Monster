using UnityEngine;

public class PopupManager : MonoSingleton<PopupManager>
{
    private GameObject curPU;

    [SerializeField] private PopupSO puConfigs;

    protected override void Awake()
    {
        base.Awake();
        ShowPU(PopupType.SettingPU);
        ClosePU();
    }
    public void ShowPU(PopupType puType)
    {
        // Create PU
        GameObject popup = puConfigs.GetPopupByType(puType);
        if(popup != null)
        {
            curPU = Instantiate(popup);
        }
    }

    public void ClosePU()
    {
        if(curPU != null)
        {
            curPU.GetComponent<PopupBase>().ClosePU();
        }
    }
}
