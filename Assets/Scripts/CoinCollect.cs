using UnityEngine;
using UnityEngine.UI;

public class CoinCollect : MonoBehaviour
{
    public float coinCountInGame;
    public int coinCount;
    public Text coinText;

    private void Start()
    {
        coinText.text = coinCountInGame.ToString();
    }
    void Update()
    {
        coinCount = PlayerPrefs.GetInt("Coins");
    }
    public void CoinCollected()
    {
        coinCountInGame++;
        coinText.text = coinCountInGame.ToString();
    }
    public void SaveCoinCount()
    {
        int finishCoinCount = coinCount + (int)coinCountInGame;
        PlayerPrefs.SetInt("Coins", finishCoinCount);
    }
    public void RaisingCoinCountInGame()
    {
        int lastCoinCountInGame = (int)coinCountInGame;
        int newCoinCountInGame = Mathf.FloorToInt(coinCountInGame * 1.5f);
        int raisingCoinCountInGame = newCoinCountInGame - lastCoinCountInGame;
        coinCountInGame += raisingCoinCountInGame;
        int finishCoinCount = coinCount + raisingCoinCountInGame;
        PlayerPrefs.SetInt("Coins", finishCoinCount);
    }
}
