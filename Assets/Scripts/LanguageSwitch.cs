using UnityEngine;
using UnityEngine.UI;

public class LanguageSwitch : MonoBehaviour
{
    public string[] languages;
    public bool[] languageSwitch;

    private Shop shop;
    void Start()
    {
        if (PlayerPrefs.GetInt("LanguageÐóñ") == 0 && PlayerPrefs.GetInt("LanguageEng") == 0 && PlayerPrefs.GetInt("LanguageEsp") == 0 && PlayerPrefs.GetInt("LanguageItal") == 0 && PlayerPrefs.GetInt("LanguageDeu") == 0 && PlayerPrefs.GetInt("LanguageÓêð") == 0)
            //SwitchLanguage("Ðóñ");
        for (int i = 0; i < languages.Length; i++)
        {
            languageSwitch[i] = PlayerPrefs.GetInt("Language" + languages[i]) == 1;
        }
        shop = FindObjectOfType<Shop>();
    }

    public void SwitchLanguage(string language)
    {
        for (int i = 0; i < languages.Length; i++)
        {
            if (languages[i] == language)
            {
                languageSwitch[i] = true; 
                PlayerPrefs.SetInt("Language" + language, 1);
                shop.LeftSwitch();
                shop.RightSwitch();
            }
            else
            {
                languageSwitch[i] = false;
                PlayerPrefs.SetInt("Language" + languages[i], 0);
            }
        }
    }    
}
