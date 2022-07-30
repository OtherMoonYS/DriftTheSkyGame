using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Doodle : MonoBehaviour
{
    public static Doodle instance;

    float horizontal;
    public Rigidbody2D DoodleRigid;
    private SpriteRenderer sp;

    [Header("Death")]
    public GameObject deathMenu;
    public Text metersText;
    private MeterCounter counter;
    private int record;
    [HideInInspector]public bool newRecord;
    void Start()
    {       
        if (instance == null)
        {
            instance = this;
        }

        sp = GetComponent<SpriteRenderer>();
        counter = FindObjectOfType<MeterCounter>();
    }


    void FixedUpdate()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            horizontal = Input.acceleration.x;
            DoodleRigid.velocity = new Vector2(horizontal * 10f, DoodleRigid.velocity.y);
            if (Input.acceleration.x < 0)
            {
                sp.flipX = false;
            }
            if (Input.acceleration.x > 0)
            {
                sp.flipX = true;
            }
        }
        else
        {
            horizontal = Input.GetAxis("Horizontal");
            DoodleRigid.velocity = new Vector2(horizontal * 10f, DoodleRigid.velocity.y);
        }        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "DeadZone")
        {            
            record = counter.CountHighestAccount();
            PlayerPrefs.SetInt("Record", record);
            deathMenu.SetActive(true);
            if (newRecord)
            {
                metersText.text = "Новый рекорд " + counter.account + " m!!!";
            }
            else
            {
                metersText.text = "Вы дошли до " + counter.account + " m";
            }
            Time.timeScale = 0f;
        }
    }
}
