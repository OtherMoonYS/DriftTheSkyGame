using UnityEngine;
using UnityEngine.UI;

public class Doodle : MonoBehaviour
{
    public static Doodle instance;

    private float horizontal;
    public Rigidbody2D DoodleRigid;
    private SpriteRenderer sp;
    private CoinCollect coinCollect;

    [Header("Death")]
    public GameObject deathMenu;
    public Text metersText;
    public Text coinsText;
    private MeterCounter counter;
    private int record;
    [HideInInspector]public bool newRecord;
    public GameObject[] onDeathDisable;
    void Start()
    {       
        if (instance == null)
        {
            instance = this;
        }

        sp = GetComponent<SpriteRenderer>();
        counter = FindObjectOfType<MeterCounter>();
        coinCollect = FindObjectOfType<CoinCollect>();
    }

    void FixedUpdate()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            horizontal = Input.acceleration.x;
            DoodleRigid.velocity = new Vector2(horizontal * 10f, DoodleRigid.velocity.y);
            if (Input.acceleration.x < 0)
            {
                sp.flipX = false;
            }
            if (Input.acceleration.x > 0)
            {
                sp.flipX = true;
            }
        }
        else
        {
            horizontal = Input.GetAxis("Horizontal");
            DoodleRigid.velocity = new Vector2(horizontal * 10f, DoodleRigid.velocity.y);
        }        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.name == "DeadZone")
        {            
            record = counter.CountHighestAccount();
            PlayerPrefs.SetInt("Record", record);
            deathMenu.SetActive(true);
            if (newRecord)
            {
                metersText.text = "Новый рекорд " + counter.account + " m!!!";
            }
            else
            {
                metersText.text = "Вы дошли до " + counter.account + " m";
            }
            coinsText.text = "Всего собрано " + coinCollect.coinCountInGame;
            coinCollect.SaveCoinCount();

            foreach (GameObject obj in onDeathDisable)
            {
                obj.SetActive(false);
            }

            Time.timeScale = 0f;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Coin"))
        {
            return;
        }
        else
        {
            coinCollect.CoinCollected();
            Destroy(other.gameObject);
        }        
    }
}
