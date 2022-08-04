using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject pausePanel;
    private bool isPause;

    public GameObject[] disableObj;
    public Text accountText;
    public Text coinsText;
    private MeterCounter counter;
    private CoinCollect coins;

    private void Start()
    {
        counter = FindObjectOfType<MeterCounter>();
        coins = FindObjectOfType<CoinCollect>();
    }

    public void OnPause()
    {
        if (isPause)
        {
            isPause = false;
            pausePanel.SetActive(false);
            foreach (GameObject obj in disableObj)
            {
                obj.SetActive(true);
            }
            Time.timeScale = 1;
        }
        else
        {
            isPause = true;            
            pausePanel.SetActive(true);
            accountText.text = $"Высота: {counter.account} m";
            coinsText.text = $"Количество монет: {coins.coinCountInGame}";
            foreach (GameObject obj in disableObj)
            {
                obj.SetActive(false);
            }
            Time.timeScale = 0;
        }
    }
}
