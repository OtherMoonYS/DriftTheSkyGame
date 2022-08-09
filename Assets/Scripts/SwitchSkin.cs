using UnityEngine;
using UnityEngine.UI;

public class SwitchSkin : MonoBehaviour
{
    public SpriteRenderer doodleImg;
    public Sprite[] skins;

    public enum Type { Game, Menu };
    public Type type;
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
    void Update()
    {
        if (type == Type.Menu)
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
}
