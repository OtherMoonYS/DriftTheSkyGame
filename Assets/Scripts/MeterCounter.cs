using UnityEngine;  
using UnityEngine.UI;                   

public class MeterCounter : MonoBehaviour
{
    private Doodle doodle;

    public int account;
    public Text accountText;

    public float meter;
    public Transform player;
    private Vector2 startPos;
     
    private int highestAccount;
    private void Start()
    {
        startPos = player.position;

        highestAccount = PlayerPrefs.GetInt("Record");

        doodle = FindObjectOfType<Doodle>();
    }   
    private void Update()
    {
        Vector2 playerPos = player.position;
        float pos = startPos.y + meter;

        if (playerPos.y > pos)
        {
            account++;
            accountText.text = account + " m";
            startPos = playerPos;
        }
    }
    public int CountHighestAccount()
    {
        int currentAccount = account;
        if (currentAccount > highestAccount)
        {
            highestAccount = currentAccount;
            doodle.newRecord = true;
            return highestAccount;
        }
        else
        {
            doodle.newRecord = false;
            return highestAccount;
        }
    }
}
