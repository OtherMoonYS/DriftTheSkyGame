using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform player;
    private Transform _transform;
    private bool canFall;

    public float transformPosY;
    public float playerPosY;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        rb.isKinematic = true; 
    }

    private void Update()
    {
        transformPosY = _transform.position.y;
        playerPosY = player.position.y;
        canFall = playerPosY + 0.5f > transformPosY;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && canFall)
        {
            rb.isKinematic = false;
        }
        else if (collision.gameObject.name.Equals("DeathZoneForPlatform"))
        {
            Destroy(gameObject);
        }
    }
}
