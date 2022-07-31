using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scenes : MonoBehaviour
{
    [Header("Record")]
    public Text recordText;
    private int record;

    [Header("Coins")]
    public Text coinsText;
    private int coins;

    private void Start()
    {
        record = PlayerPrefs.GetInt("Record");
        if(recordText != null)
            recordText.text = "Рекорд: " + record + " m";

        coins = PlayerPrefs.GetInt("Coins");
        if (coinsText != null)
            coinsText.text = coins.ToString();
    }
    public void ChangeScenes(int numberScenes)
    {
        SceneManager.LoadScene(numberScenes);
        Time.timeScale = 1;
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        Time.timeScale = 1;
    }

    public void Exit()
    {
        Application.Quit();
    }
}