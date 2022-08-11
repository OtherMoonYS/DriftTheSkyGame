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
    public GameObject ButSound;
    private Transform _transform;
    private TranslateText translateText;

    [Header("Sprites")]
    public Sprite OnPauseSp;
    public Sprite OffPauseSp;
    private Image pauseButImage;
    public GameObject pauseBut;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }
    private void Start()
    {
        counter = FindObjectOfType<MeterCounter>();
        coins = FindObjectOfType<CoinCollect>();
        translateText = FindObjectOfType<TranslateText>();
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
            Instantiate(ButSound, _transform.position, Quaternion.identity);
            Time.timeScale = 1;
        }
        else
        {
            isPause = true;            
            pausePanel.SetActive(true);
            string[] translates1 = new string[] { "Текущий счёт: " + counter.account, "Current score: " + counter.account, "Cuenta corriente: " + counter.account, "Conto corrente: " + counter.account, "Girokonto: " + counter.account, "Поточний рахунок: " + counter.account };
            string[] translates2 = new string[] { "Собрано монет: " + coins.coinCountInGame, "Current coins: " + coins.coinCountInGame, "Monedas recogidas: " + coins.coinCountInGame, "Monete raccolte: " + coins.coinCountInGame, "Münzen gesammelt: " + coins.coinCountInGame, "Монет зібрано: " + coins.coinCountInGame, };
            accountText.text = translateText.Translate(translates1);
            coinsText.text = translateText.Translate(translates2);
            foreach (GameObject obj in disableObj)
            {
                obj.SetActive(false);
            }
            pauseButImage.sprite = OnPauseSp;
            Instantiate(ButSound, _transform.position, Quaternion.identity);
            Time.timeScale = 0;
        }
    }
}
