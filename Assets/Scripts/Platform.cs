using UnityEngine;

public class Platform : MonoBehaviour
{
    public float forceJump = 7.5f;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y < 0)
        {                
            Doodle.instance.DoodleRigid.velocity = Vector2.up * forceJump;
        }        
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.name == "DeadZoneForPlatform") 
        {            
            Destroy(gameObject);
        }
    }
}
