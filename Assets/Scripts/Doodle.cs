using UnityEngine;
using UnityEngine.UI;

public class Doodle : MonoBehaviour
{
    public static Doodle instance;

    private float horizontal;
    public Rigidbody2D DoodleRigid;
    private CoinCollect coinCollect;
    private Transform _transform;
    private bool facingRight = true;
    public float speed;

    [Header("Raycast")]
    public LayerMask trap;
    public float rayDistance;

    [Header("Death")]
    public GameObject deathMenu;
    public Text metersText;
    public Text coinsText;
    public Text recordText;
    private MeterCounter counter;
    private int record;
    [HideInInspector] public bool newRecord;
    public GameObject[] onDeathDisable;
    public int startDeathCount;
    private int deathCount;
    private bool canMinus = true;
    private InerstitialAds inerstitialAds;
    private RewardedAds rewAds;

    [Header("Bonus")]
    public float startAnvulnerabilityTime;
    private float anvulnerabilityTime;
    private bool anvulnerability;
    private bool shieldAnvulnerability;
    public float startShieldAnvulnerabilityTime;
    private float shieldAnvulnerabilityTime;
    public GameObject shield;
    private Animator shieldAnim;
    private bool isAssign1;

    [Header("Sounds")]
    public GameObject HitByTrapEnemy;
    public GameObject Upal;
    public GameObject PickUpCoin;
    public GameObject shieldStart;
    private bool soundPlayed = false;
    [Header("TimeScale")]
    public float timeScale;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        counter = FindObjectOfType<MeterCounter>();
        coinCollect = FindObjectOfType<CoinCollect>();
        _transform = GetComponent<Transform>();
        inerstitialAds = FindObjectOfType<InerstitialAds>();
        rewAds = FindObjectOfType<RewardedAds>();
        shieldAnim = shield.GetComponent<Animator>();

        rewAds.LoadAd();

        deathCount = PlayerPrefs.GetInt("deathCount");
        shieldAnvulnerabilityTime = startShieldAnvulnerabilityTime;

        Time.timeScale = timeScale;
    }

    void FixedUpdate()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            horizontal = Input.acceleration.x;
        }
        else
        {
            horizontal = Input.GetAxis("Horizontal");
        }

        DoodleRigid.velocity = new Vector2(horizontal * speed, DoodleRigid.velocity.y);        
    }

    private void Update()
    {
        timeScale = Time.timeScale;

        if (horizontal < 0 && facingRight)
        {
            Flip();
        }
        if (horizontal > 0 && !facingRight)
        {
            Flip();
        }

        RaycastHit2D ray = Physics2D.Raycast(_transform.position, Vector2.up, rayDistance, trap);
        RaycastHit2D leftRay = Physics2D.Raycast(_transform.position, Vector2.left, 0.25f, trap);
        RaycastHit2D rightRay = Physics2D.Raycast(_transform.position, Vector2.right, 0.25f, trap);
        if (ray.collider != null)
        {
            if (!anvulnerability && !shieldAnvulnerability)
            {                
                if (soundPlayed == false)
                {
                    Death();
                    Instantiate(HitByTrapEnemy, _transform.position, Quaternion.identity);
                    soundPlayed = true;
                }                
            }
        }
        else if (leftRay.collider != null)
        {
            if (!anvulnerability && !shieldAnvulnerability)
            {
                if (soundPlayed == false)
                {
                    Death();
                    Instantiate(HitByTrapEnemy, _transform.position, Quaternion.identity);
                    soundPlayed = true;
                }
            }
        }
        else if (rightRay.collider != null)
        {
            if (!anvulnerability && !shieldAnvulnerability)
            {
                if (soundPlayed == false)
                {
                    Death();
                    Instantiate(HitByTrapEnemy, _transform.position, Quaternion.identity);
                    soundPlayed = true;
                }
            }
        }


        if (startAnvulnerabilityTime > 0)
        {
            if(isAssign1 == false)
                Assign1();
        }        

        if (anvulnerabilityTime <= 0)
        {
            startAnvulnerabilityTime = 0;
            anvulnerability = false;
            isAssign1 = false;
        }
        else
        {
            anvulnerabilityTime -= Time.deltaTime;
            anvulnerability = true;
        }

        if (shieldAnvulnerability)
        {
            if (shieldAnvulnerabilityTime <= 0)
            {
                shieldAnvulnerability = false;
                shieldAnvulnerabilityTime = startShieldAnvulnerabilityTime;
                shield.SetActive(false);
            }
            else
            {
                shieldAnvulnerabilityTime -= Time.deltaTime;
                shield.SetActive(true);
                if (shieldAnvulnerabilityTime <= 2)
                {
                    shieldAnim.Play("ShieldAnim");
                }
            }
        }        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.name == "DeadZone")
        {
            Death();
            Instantiate(Upal, _transform.position, Quaternion.identity);
        }        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            coinCollect.CoinCollected();
            Destroy(other.gameObject);
            Instantiate(PickUpCoin, _transform.position, Quaternion.identity);
        }
        else if (other.CompareTag("Shield"))
        {
            if (!shieldAnvulnerability)
                shieldAnvulnerability = true;
            else
            {
                shieldAnvulnerabilityTime = startShieldAnvulnerabilityTime;
                shieldAnim.Play("ShieldIdle");
            }
            Instantiate(shieldStart, _transform.position, Quaternion.identity);    
            Destroy(other.gameObject);
        }

        if (other.GetComponent<Enemy>() != null)
        {
            if (!anvulnerability && !shieldAnvulnerability)
            {
                Death();
                Instantiate(HitByTrapEnemy, _transform.position, Quaternion.identity);                   
            }      
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = _transform.localScale;
        Scaler.x *= -1;
        _transform.localScale = Scaler;
    }
    void Death()
    {
        record = counter.CountHighestAccount();

        deathMenu.SetActive(true);

        if (newRecord)
        {
            metersText.text = "Новый рекорд " + counter.account + "!";
        }
        else
        {
            metersText.text = "Текущий счёт: " + counter.account;
        }

        coinsText.text = "Всего собрано: " + coinCollect.coinCountInGame;
        coinCollect.SaveCoinCount();

        recordText.text = "Ваш рекорд: " + record;

        foreach (GameObject obj in onDeathDisable)
        {
            obj.SetActive(false);
        }

        if (canMinus)
        {
            DeathMinus();
            canMinus = false;
        }                
            
        Time.timeScale = 0;
    }

    void Assign1()
    {
        anvulnerabilityTime = startAnvulnerabilityTime;
        isAssign1 = true;
    }
    void DeathMinus()
    {
        if (deathCount == 0)
        {
            deathCount = startDeathCount;
            PlayerPrefs.SetInt("deathCount", deathCount);
            inerstitialAds.ShowAd();
            return;
        }
        deathCount--;
        PlayerPrefs.SetInt("deathCount", deathCount);        
    }    
}
