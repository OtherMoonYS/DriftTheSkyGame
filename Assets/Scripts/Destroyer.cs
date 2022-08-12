using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public float lifeTime;
    public enum DestroyType { Time, OnTrigger, Blank };
    public DestroyType type;

    private Transform _transform;

    private void Awake()
    {
        if (type.Equals(DestroyType.Blank))
            _transform = GetComponent<Transform>();
    }

    void Update()
    {
        if(type == DestroyType.Time)
            Destroy(gameObject, lifeTime);
        else if (type.Equals(DestroyType.Blank))
        {
            if (_transform.childCount.Equals(0))
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (type == DestroyType.OnTrigger)
        {
            if (other.gameObject.name == "DeadZoneForPlatform")
            {
                Destroy(gameObject);
            }
        }
    }
}
