using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class RewardedAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public Button rewardedBut;

    public string androidID = "Rewarded_Android";
    public string iosID = "Rewarded_IOS";
    private string adID;

    private CoinCollect coins;
   

    void Awake()
    {
        adID = Application.platform == RuntimePlatform.IPhonePlayer ? iosID : androidID;
        rewardedBut.interactable = false;
    }
    private void Start()
    {
        LoadAd();
        coins = FindObjectOfType<CoinCollect>();
    }

    void LoadAd()
    {
        Advertisement.Load(adID, this);
    }
    public void ShowAd()
    {
        Advertisement.Show(adID, this);
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        if (placementId.Equals(adID))
        {
            rewardedBut.onClick.AddListener(ShowAd);

            rewardedBut.interactable = true;
        }
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if (placementId == adID && showCompletionState == UnityAdsShowCompletionState.COMPLETED)
        {
            coins.coinCountInGame = RaisingCoins(coins.coinCountInGame);
            rewardedBut.interactable = false;
        }
    }
    float RaisingCoins(float coins)
    {
        coins *= 1.5f;
        return Mathf.Round(coins);
    }
}
