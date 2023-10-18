using System;
using Toga.Ads;
using UnityEngine;

public class AdManager : MonoSingleton<AdManager>
{
    [SerializeField] private CommonRewardAdController rewardController;
    [SerializeField] private CommonInterstitialAdController interstitialAdController;

    public bool IsInterstitialLoaded => interstitialAdController.IsLoadedAd();
    public bool IsRewardedLoaded => rewardController.IsLoadedAd();

    public bool ShowIntersitialAd(Action onCloseAction = null)
    {
        if(!IsInterstitialLoaded)
        {
            ConsoleLog.LogError("Interstitial is not loaded");
            return false;
        }
        else
        {
            interstitialAdController.RegisterCloseAdCallback(onCloseAction);
            interstitialAdController.StartShowAd();
        }
        return true;
    }

    public bool ShowRewardedAd(Action onSuccessWatchAd = null, Action onCloseAction = null)
    {
        if (!IsRewardedLoaded)
        {
            ConsoleLog.LogError("Interstitial is not loaded");
            return false;
        }
        else
        {
            rewardController.RegisterSuccessWatchAdAdCallback(onSuccessWatchAd);
            rewardController.RegisterCloseRewardAdCallback(onCloseAction);
            rewardController.StartShowAd();
        }
        return true;
    }
}
