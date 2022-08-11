using UnityEngine;

public class Platform : MonoBehaviour
{
    public float forceJump = 7.5f;
    private Doodle doodle;
    private Transform _transform;
    private RewardedAds rewAds;

    public enum PlatformType { Usuale, Bonus };
    public PlatformType type;
    
    public enum BonusTime {Small, Little, Middle, High }
    public BonusTime bonusTime;

    [Header("Bonuses")]
    public float smallBonusTime;
    public float littleBonusTime;
    public float middleBonusTime;
    public float highBonusTime;

    [Header("Sounds")]
    public GameObject Jump;
    public GameObject LowBonus;
    public GameObject MidBonus;
    public GameObject MaxBonus;
    public GameObject PrujinaBonus;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        rewAds = FindObjectOfType<RewardedAds>();
    }
    private void Start()
    {
        doodle = FindObjectOfType<Doodle>();
        rewAds.LoadAd();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y < 0)
        {                
            if (type == PlatformType.Bonus)
            {
                if (bonusTime == BonusTime.Small)
                {
                    Instantiate(PrujinaBonus, _transform.position, Quaternion.identity);
                    doodle.startAnvulnerabilityTime = smallBonusTime;
                }
                else if (bonusTime == BonusTime.Little)
                {
                    Instantiate(LowBonus, _transform.position, Quaternion.identity);
                    doodle.startAnvulnerabilityTime = littleBonusTime;
                }
                else if (bonusTime == BonusTime.Middle)
                {
                    Instantiate(MidBonus, _transform.position, Quaternion.identity);
                    doodle.startAnvulnerabilityTime = middleBonusTime;
                }
                else if (bonusTime == BonusTime.High)
                {
                    Instantiate(MaxBonus, _transform.position, Quaternion.identity);
                    doodle.startAnvulnerabilityTime = highBonusTime;
                }

                Doodle.instance.DoodleRigid.velocity = Vector2.up * forceJump;
            }
            Instantiate(Jump, _transform.position, Quaternion.identity);
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
