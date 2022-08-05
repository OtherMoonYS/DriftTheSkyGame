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

    [Header("Sprites")]
    public Sprite OnPauseSp;
    public Sprite OffPauseSp;
    private Image pauseButImage;
    public GameObject pauseBut;

    private void Start()
    {
        counter = FindObjectOfType<MeterCounter>();
        coins = FindObjectOfType<CoinCollect>();
        pauseButImage = pauseBut.GetComponent<Image>();
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
            pauseButImage.sprite = OffPauseSp;
            Time.timeScale = 1;
        }
        else
        {
            isPause = true;            
            pausePanel.SetActive(true);
            accountText.text = $"Текущий счет: {counter.account} m";
            coinsText.text = $"Собрано монет: {coins.coinCountInGame}";
            foreach (GameObject obj in disableObj)
            {
                obj.SetActive(false);
            }
            pauseButImage.sprite = OnPauseSp;
            Time.timeScale = 0;
        }
    }
}
