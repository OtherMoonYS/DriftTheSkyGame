using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public float lifeTime;
    void Update()
    {
        Destroy(gameObject, lifeTime);
    }
}
