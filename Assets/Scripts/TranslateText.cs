using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateText : MonoBehaviour
{
    public string Translate(string[] translates)
    {
        if (PlayerPrefs.GetInt("LanguageĞóñ") == 1)
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
        if (PlayerPrefs.GetInt("LanguageÓêğ") == 1)
        {
            return translates[5];
        }
        return null;
    }
}
