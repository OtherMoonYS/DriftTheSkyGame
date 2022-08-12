using UnityEngine;
using UnityEngine.UI;

public class TextSwitch : MonoBehaviour
{
    private Text text;
    [Header("���, Eng, Esp, Ital, Deu, ���")]
    public string[] translates;

    void Start()
    {
        text = GetComponent<Text>();        
    }
    void Update()
    {
        text.text = Translate(translates);
    }
    public string Translate(string[] translates)
    {
        if (PlayerPrefs.GetInt("Language���") == 1)
        {
            return translates[0];
        }
        if (PlayerPrefs.GetInt("LanguageEng") == 1)
        {
            return translates[1];
        }
        if (PlayerPrefs.GetInt("LanguageEsp") == 1)
        {
            return translates[2];
        }
        if (PlayerPrefs.GetInt("LanguageItal") == 1)
        {
            return translates[3];
        }
        if (PlayerPrefs.GetInt("LanguageDeu") == 1)
        {
            return translates[4];
        }
        if (PlayerPrefs.GetInt("Language���") == 1)
        {
            return translates[5];
        }
        return null;
    }
}
