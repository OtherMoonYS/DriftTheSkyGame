using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(name == "R")
            {
                collision.gameObject.transform.position = new Vector3(-3.15f, collision.gameObject.transform.position.y, 0f);
            }    
            if (name == "L")
            {
                collision.gameObject.transform.position = new Vector3(3.15f, collision.gameObject.transform.position.y, 0f);
            }
        }
    }
}