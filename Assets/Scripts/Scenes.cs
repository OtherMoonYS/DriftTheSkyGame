using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public void ChangeScences(int nubmerScenes)
    {
        SceneManager.LoadScene(nubmerScenes);
    }


    public void Exit()
    {
        Application.Quit();
    }
}