using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    public Transform L;
    public float offset;
    public Transform R;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Doodle>() != null)
        {
            if(name == "R")
            {
                collision.gameObject.transform.position = new Vector2(L.position.x + offset, collision.gameObject.transform.position.y);
            }    
            if (name == "L")
            {
                collision.gameObject.transform.position = new Vector2(R.position.x - offset, collision.gameObject.transform.position.y);
            }
        }
    }
}