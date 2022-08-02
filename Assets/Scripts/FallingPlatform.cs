using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D box;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        rb.isKinematic = true; 
    }
        
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Doodle>() != null && collision.relativeVelocity.y < 0)
        {
            rb.isKinematic = false;
            box.enabled = false;
        }
    }
}
