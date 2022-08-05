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

    [Header("Bonus")]
    public float startAnvulnerabilityTime;
    private float anvulnerabilityTime;
    private bool anvulnerability;
    private bool isAssign;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        counter = FindObjectOfType<MeterCounter>();
        coinCollect = FindObjectOfType<CoinCollect>();
        _transform = GetComponent<Transform>();
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
        if (horizontal < 0 && facingRight)
        {
            Flip();
        }
        if (horizontal > 0 && !facingRight)
        {
            Flip();
        }

        RaycastHit2D ray = Physics2D.Raycast(_transform.position, Vector2.up, rayDistance, trap);
        if (ray.collider != null)
        {
            if (anvulnerability == false)
                Death();
        }

        if (startAnvulnerabilityTime > 0)
        {
            if(isAssign == false)
                Assign();
        }

        if (anvulnerabilityTime <= 0)
        {
            startAnvulnerabilityTime = 0;
            anvulnerability = false;
            isAssign = false;
        }
        else
        {
            anvulnerabilityTime -= Time.deltaTime;
            anvulnerability = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.name == "DeadZone")
        {            
            if (anvulnerability == false)
                Death();
        }        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            coinCollect.CoinCollected();
            Destroy(other.gameObject);
        }

        if (other.GetComponent<Enemy>() != null)
        {
            if (anvulnerability == false)
                Death();
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
            metersText.text = "Новый рекорд " + counter.account + " m!!!";
        }
        else
        {
            metersText.text = "Вы дошли до " + counter.account + " m";
        }

        coinsText.text = "Всего собрано: " + coinCollect.coinCountInGame;
        coinCollect.SaveCoinCount();

        recordText.text = "Ваш рекорд: " + record + " m";

        foreach (GameObject obj in onDeathDisable)
        {
            obj.SetActive(false);
        }

        Time.timeScale = 0;
    }

    void Assign()
    {
        anvulnerabilityTime = startAnvulnerabilityTime;
        isAssign = true;
    }
}
