using System;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] private bool isTestAds = true;
    public static AdsManager adsManagerInstace;
    Action onRewardedAdSuccess; // action when the user finished RV

    #region AdsID
#if UNITY_ANDROID
     const string gameID = "4276747";
#elif UNITY_IOS
 const string gameID = "4276746";
#endif
#if UNITY_ANDROID
     const string rewardedAdID = "Rewarded_Video";
#elif UNITY_IOS
const string rewardedAdID = "Rewarded_Video";
#endif
#if UNITY_ANDROID
    const string InterstitialID = "Interstitial_android";
#elif UNITY_IOS
 const string InterstitialID = "Interstitial_ios";
#endif
    #endregion

    #region Singleton
    private void Awake()
    {
        if (adsManagerInstace != null && adsManagerInstace != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            adsManagerInstace = this;
            DontDestroyOnLoad(gameObject);
            Advertisement.AddListener(this);
            Advertisement.Initialize(gameID, isTestAds);
        }
    }
    #endregion

    // RV ads
    public void ShowAd(Action onSuccess)
    {
        onRewardedAdSuccess = onSuccess;

        // checking if the RV is ready
        if (Advertisement.IsReady(InterstitialID))
        {
            Advertisement.Show(rewardedAdID);
        }
    }

    public void LoadAd()
    {
        Advertisement.Load(InterstitialID);
    }

    // Interstital ads
    public void ShowInterAd()
    {
        Advertisement.Show(InterstitialID);
    }

    public void OnUnityAdsReady(string placementId)
    {
    }

    public void OnUnityAdsDidStart(string placementId)
    {
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch (showResult)
        {
            // Only if the user has finished an RV he will get the reward
            case ShowResult.Finished:
                if (placementId == rewardedAdID)
                {
                    onRewardedAdSuccess.Invoke();
                }
                break;

            case ShowResult.Skipped:
                if (placementId == rewardedAdID)
                {
                    Debug.Log("The user skipped the ad and he won't get his reward");
                }
                break;
            case ShowResult.Failed:
                OnUnityAdsDidError("Error showing the ad");
                break;
        }
    }
    public void OnUnityAdsDidError(string message)
    {
    }
}