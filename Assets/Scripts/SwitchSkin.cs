using UnityEngine;
using UnityEngine.UI;

public class SwitchSkin : MonoBehaviour
{
    public SpriteRenderer doodleImg;
    public Sprite[] skins;
    void Start()
    {
        for (int i = 0; i < skins.Length; i++)
        {
            if (PlayerPrefs.GetInt("Select" + i) == 1)
            {
                doodleImg.sprite = skins[i];
            }
        }
    }
}
