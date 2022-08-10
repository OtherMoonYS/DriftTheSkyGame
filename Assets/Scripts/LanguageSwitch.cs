using UnityEngine;
using UnityEngine.UI;

public class LanguageSwitch : MonoBehaviour
{
    public string[] languages;
    public bool[] languageSwitch;
    public int[] ints;
    void Start()
    {
        if (PlayerPrefs.GetInt("LanguageEng") == 0 && PlayerPrefs.GetInt("LanguageEsp") == 0 && PlayerPrefs.GetInt("LanguageItal") == 0 && PlayerPrefs.GetInt("LanguageDeu") == 0 && PlayerPrefs.GetInt("LanguageÓêð") == 0)
            SwitchLanguage("Ðóñ");
        for (int i = 0; i < languages.Length; i++)
        {
            languageSwitch[i] = PlayerPrefs.GetInt("Language" + languages[i]) == 1;
        }
    }

    private void Update()
    {
        for (int i = 0; i < languages.Length; i++)
        {
            ints[i] = PlayerPrefs.GetInt("Language" + languages[i]);
        }
    }

    public void SwitchLanguage(string language)
    {
        for (int i = 0; i < languages.Length; i++)
        {
            if (languages[i] == language)
            {
                languageSwitch[i] = true; 
                PlayerPrefs.SetInt("Language " + language, 1);
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
}
