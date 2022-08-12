using UnityEngine;

public class LanguageSwitch : MonoBehaviour
{
    public string[] languages;
    public bool[] languageSwitch;

    void Start()
    {
        if (!PlayerPrefs.HasKey("LanguageÐóñ") && !PlayerPrefs.HasKey("LanguageEng") && !PlayerPrefs.HasKey("LanguageEsp") && !PlayerPrefs.HasKey("LanguageItal") && !PlayerPrefs.HasKey("LanguageDeu") && !PlayerPrefs.HasKey("LanguageÓêð"))
        {
            if (Application.systemLanguage == SystemLanguage.Russian)
            {
                SwitchLanguage("Ðóñ");
            }
            else if (Application.systemLanguage == SystemLanguage.English)
            {
                SwitchLanguage("Eng");
            }
            else if (Application.systemLanguage == SystemLanguage.Spanish)
            {
                SwitchLanguage("Esp");
            }
            else if (Application.systemLanguage == SystemLanguage.Italian)
            {
                SwitchLanguage("Ital");
            }
            else if (Application.systemLanguage == SystemLanguage.German)
            {
                SwitchLanguage("Deu");
            }
            else if (Application.systemLanguage == SystemLanguage.Ukrainian)
            {
                SwitchLanguage("Óêð");
            }
        }

        for (int i = 0; i < languages.Length; i++)
        {
            languageSwitch[i] = PlayerPrefs.GetInt("Language" + languages[i]) == 1;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Reset();
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
            }
            else
            {
                languageSwitch[i] = false;
                PlayerPrefs.SetInt("Language" + languages[i], 0);
            }
        }
    }
    private void Reset()
    {
        for (int i = 0; i < languages.Length; i++)
        {
            PlayerPrefs.DeleteKey("Language" + languages[i]);
        }
    }
}
