using UnityEngine;
using UnityEngine.Advertisements;

public class InerstitialAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener 
{
    public string androidID = "Inerstitial_Android";
    public string iosID = "Inerstitial_IOS";
    private string gameID;
    void Start()
    {
        gameID = Application.platform == RuntimePlatform.IPhonePlayer ? iosID : androidID;
        LoadAd();
    }

    public void LoadAd()
    {
        Advertisement.Load(gameID, this);
    }

    public void ShowAd()
    {
        Advertisement.Show(gameID, this);
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        //throw new System.NotImplementedException();
        LoadAd();
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        //throw new System.NotImplementedException();
    }    
}
