using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class RewardedAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public Button rewardedBut;
    private Transform _transform;

    public string androidID = "Rewarded_Android";
    public string iosID = "Rewarded_IOS";
    private string adID;

    private CoinCollect coins;
    private TranslateText translateText;
    public Text coinsText;

    private bool canRaising = true;

    public GameObject doubleCoins;
   

    void Awake()
    {
        adID = Application.platform == RuntimePlatform.IPhonePlayer ? iosID : androidID;
        rewardedBut.interactable = false;
    }
    private void Start()
    {
        LoadAd();
        coins = FindObjectOfType<CoinCollect>();
        _transform = GetComponent<Transform>();
        translateText = FindObjectOfType<TranslateText>();
    }

    public void LoadAd()
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
        
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        
    }

    public void OnUnityAdsShowClick(string placementId)
    {
       
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if (placementId == adID && showCompletionState == UnityAdsShowCompletionState.COMPLETED)
        {
            if (canRaising)
            {
                coins.RaisingCoinCountInGame();
                string[] translates = new string[] { "Всего собрано: " + coins.coinCountInGame, "Total collected: " + coins.coinCountInGame, "Total recogido: " + coins.coinCountInGame, "Totale raccolto: " + coins.coinCountInGame, "Insgesamt gesammelt: " + coins.coinCountInGame, "Всього зібрано: " + coins.coinCountInGame };
                coinsText.text = translateText.Translate(translates);
                Instantiate(doubleCoins, _transform.position, Quaternion.identity);
                rewardedBut.interactable = false;
                canRaising = false;
            }            
        }
    }

}
