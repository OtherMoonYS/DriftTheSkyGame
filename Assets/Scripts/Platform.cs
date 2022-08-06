using UnityEngine;

public class Platform : MonoBehaviour
{
    public float forceJump = 7.5f;
    private Doodle doodle;

    public enum PlatformType { Usuale, Bonus };
    public PlatformType type;
    
    public enum BonusTime {Small, Little, Middle, High }
    public BonusTime bonusTime;

    [Header("Bonuses")]
    public float smallBonusTime;
    public float littleBonusTime;
    public float middleBonusTime;
    public float highBonusTime;

    private void Start()
    {
        doodle = FindObjectOfType<Doodle>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y < 0)
        {                
            if (type == PlatformType.Bonus)
            {
                if(bonusTime == BonusTime.Small)
                    doodle.startAnvulnerabilityTime = smallBonusTime;
                else if (bonusTime == BonusTime.Little)
                    doodle.startAnvulnerabilityTime = littleBonusTime;
                else if (bonusTime == BonusTime.Middle)
                    doodle.startAnvulnerabilityTime = middleBonusTime;
                else if (bonusTime == BonusTime.High)
                    doodle.startAnvulnerabilityTime = highBonusTime;
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
