using System.Collections;
using System.Collections.Generic;
using UnityEngine;  
using UnityEngine.UI;                   

public class MeterCounter : MonoBehaviour
{
    public int account;
    public Text accountText;

    public float meter;
    public Transform player;
    private Vector2 startPos;

    private int currentAccount;
    private int highestAccount;
    private void Start()
    {
        startPos = player.position;
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
        currentAccount = account;
        if (currentAccount > highestAccount)
        {
            highestAccount = currentAccount;
            return highestAccount;
        }
        else
        {
            return highestAccount;
        }
    }
}
