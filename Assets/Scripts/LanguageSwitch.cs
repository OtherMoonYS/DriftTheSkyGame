using UnityEngine;
using UnityEngine.UI;

public class LanguageSwitch : MonoBehaviour
{
    public string[] languages;
    public bool[] languageSwitch;
    void Start()
    {
        if (PlayerPrefs.GetInt("LanguageEng") == 0 && PlayerPrefs.GetInt("LanguageEsp") == 0 && PlayerPrefs.GetInt("LanguageItal") == 0 && PlayerPrefs.GetInt("LanguageDeu") == 0 && PlayerPrefs.GetInt("LanguageÓêð") == 0)
            SwitchLanguage("Ðóñ");
        for (int i = 0; i < languages.Length; i++)
        {
            languageSwitch[i] = PlayerPrefs.GetInt("Language" + languages[i]) == 1;
        }
    }

    public void SwitchLanguage(string language)
    {
        for (int i = 0; i < languages.Length; i++)
        {
            if (languages[i] == language)
            {
                languageSwitch[i] = true; 
                PlayerPrefs.SetInt("Language" + language, 1);
                for (int s = 0; s < languages.Length; s++)
                {
                    if (languages[s] == languages[i])
                    {
                        continue;
                    }
                    else
                    {
                        languageSwitch[s] = false;
                        PlayerPrefs.SetInt("Language" + languages[s], 0);
                    }
                }
            }
        }
    }
    public string Translate(string[] translates)
    {
        if (PlayerPrefs.GetInt("LanguageÐóñ") == 1)
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
        if (PlayerPrefs.GetInt("LanguageÓêð") == 1)
        {
            return translates[5];
        }
        return null;
    }
}
