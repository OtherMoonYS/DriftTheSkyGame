using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scenes : MonoBehaviour
{
    [Header("Record")]
    public Text recordText;
    private TranslateText translateText;
    private int record;

    public GameObject soundObj;
    private Transform _transform;

    private void Start()
    {
        translateText = FindObjectOfType<TranslateText>();
        record = PlayerPrefs.GetInt("Record");
             
        _transform = GetComponent<Transform>();
    }
    private void Update()
    {
        if (recordText != null)
        {
            string[] translates = new string[] { "Рекорд: " + record, "Record: " + record, "Récord: " + record, "Record: " + record, "Rekord: " + record, "Рекорд: " + record };
            recordText.text = translateText.Translate(translates);
        }
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