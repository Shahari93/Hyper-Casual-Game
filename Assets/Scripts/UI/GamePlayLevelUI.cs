using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GamePlayLevelUI : MonoBehaviour, IRewardAd
{
    [SerializeField] private RectTransform settingsButton;
    [SerializeField] private GameObject settingsScreen;
    [SerializeField] private RectTransform backButton;
    [SerializeField] private RectTransform shopButton;
    [SerializeField] private GameObject shopScreen;
    [SerializeField] private Button startGameRVButton;

    public void SettingsScreen()
    {
        settingsButton.DOPivotX(2, 0.5f);
        backButton.DOPivotX(0.5f, 0.5f);
        settingsScreen.SetActive(true);
    }

    public void BackButton()
    {
        backButton.DOPivotX(2, 0.5f);
        settingsButton.DOPivotX(0.5f, 0.5f);
        settingsScreen.SetActive(false);
        if (shopButton.gameObject.activeInHierarchy)
        {
            shopScreen.SetActive(false);
        }
    }

    public void ShopButton()
    {
        shopButton.DOPivotX(-2, 0.5f);
        shopScreen.SetActive(true);
    }

    // When game starts the UI is moving out of the game screen
    public void OnGameStarted()
    {
        shopButton.DOPivotX(-2, 0.5f);
        backButton.DOPivotX(2, 0.5f);
        startGameRVButton.gameObject.SetActive(false);
    }

    // Need to add those 2 methods from IRewardAd interface (GetReward, OnRewardedAdSuccess) so the rewarded will work
    public void GetReward()
    {
        AdsManager.adsManagerInstace.ShowAd(OnRewardedAdSuccess);
    }

    public void OnRewardedAdSuccess()
    {
        Debug.Log("Player Got prize");
        startGameRVButton.interactable = false;
    }
}