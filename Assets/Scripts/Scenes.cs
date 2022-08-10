using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scenes : MonoBehaviour
{
    [Header("Record")]
    public Text recordText;
    private int record;

    public GameObject soundObj;
    private Transform _transform;

    private void Start()
    {
        record = PlayerPrefs.GetInt("Record");
        if(recordText != null)
            recordText.text = "Рекорд: " + record;

        _transform = GetComponent<Transform>();
    }
    public void ChangeScenes(int numberScenes)
    {
        SceneManager.LoadScene(numberScenes);
        Instantiate(soundObj, _transform.position, Quaternion.identity);
        Time.timeScale = 1;
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        Instantiate(soundObj, _transform.position, Quaternion.identity);
        Time.timeScale = 1;
    }
    public void Exit()
    {
        Application.Quit();
        Instantiate(soundObj, _transform.position, Quaternion.identity);
    }
    public void ButSoundPlay()
    {
        Instantiate(soundObj, _transform.position, Quaternion.identity);
    }
}