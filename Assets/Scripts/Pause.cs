using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pausePanel;
    private bool isPause;
   
    public void OnPause()
    {
        if (isPause)
        {
            isPause = false;
            pausePanel.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            isPause = true;            
            pausePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
