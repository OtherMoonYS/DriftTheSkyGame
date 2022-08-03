using UnityEngine;

public class Platform : MonoBehaviour
{
    public float forceJump = 7.5f;
    public Transform player;
    public Vector2 finishPos;

    public enum PlatformType { Usuale, Bonus }
    public PlatformType type;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y < 0)
        {
            if (type == PlatformType.Bonus)
            {
                Vector2 playerPos = player.position;
                finishPos = playerPos + Vector2.up * forceJump;
            }            

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
