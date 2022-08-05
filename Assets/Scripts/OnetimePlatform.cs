using UnityEngine;

public class OnetimePlatform : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.GetComponent<Doodle>() != null && other.relativeVelocity.y < 0)
        anim.SetTrigger("Disappearance");
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
