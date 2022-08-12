using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
{
    public string androidID = "4874511";
    public string iosID = "4874510";
    public bool testMode = true;
    private string gameID;
    void Start()
    {
        AdsInitialize();
    }

    void AdsInitialize()
    {
        gameID = Application.platform == RuntimePlatform.IPhonePlayer ? iosID : androidID;
        Advertisement.Initialize(gameID, testMode, this);
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Инициализация успешно пройдена!");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log("Инициализация не прошла( проверь подключение к сети что-ли");
    }
}
