using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollect : MonoBehaviour
{
    public int coinCountInGame;
    public int coinCount;
    public Text coinText;
        
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
        int finishCoinCount = coinCount + coinCountInGame;
        PlayerPrefs.SetInt("Coins", finishCoinCount);
    }
}
