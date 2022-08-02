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
    private MeterCounter counter;
    private int record;
    [HideInInspector] public bool newRecord;
    public GameObject[] onDeathDisable;
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
            Death();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.name == "DeadZone")
        {            
            Death();
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

        Time.timeScale = 0;
    }
}
