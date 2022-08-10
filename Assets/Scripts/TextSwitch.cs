using UnityEngine;
using UnityEngine.UI;

public class TextSwitch : MonoBehaviour
{
    private Text text;
    [Header("Ðóñ, Eng, Esp, Ital, Deu, Óêð")]
    public string[] translates;

    private bool[] languages;
    void Start()
    {
        text = GetComponent<Text>();        
    }

    void Update()
    {


        if (PlayerPrefs.GetInt("LanguageÐóñ") == 1)
        {
            text.text = translates[0];
        }
        if(PlayerPrefs.GetInt("LanguageEng") == 1)
        {
            text.text = translates[1];
        }
        if (PlayerPrefs.GetInt("LanguageEsp") == 1)
        {
            text.text = translates[2];
        }
        if (PlayerPrefs.GetInt("LanguageItal") == 1)
        {
            text.text = translates[3];
        }
        if (PlayerPrefs.GetInt("LanguageDeu") == 1)
        {
            text.text = translates[4];
        }
        if (PlayerPrefs.GetInt("LanguageÓêð") == 1)
        {
            text.text = translates[5];
        }
    }
}
