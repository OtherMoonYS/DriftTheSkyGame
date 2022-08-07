using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Image[] skinsImages;
    public Sprite[] skinsSprites;
    private int skinIndex0;
    private int skinIndex1;
    private int skinIndex2;
    void Start()
    {        
        
    }

    void Update()
    {
        
    }
    public void LeftSwitch()
    {
        if (skinsImages[0].sprite == skinsSprites[0])
        {
            skinsImages[0].sprite = skinsSprites[skinsSprites.Length - 1];
        }
        else
        {
            skinIndex0 = GetIndexSprite(skinsImages[0]);
            skinsImages[0].sprite = skinsSprites[skinIndex0 - 1];
        }

        if (skinsImages[1].sprite == skinsSprites[0])
        {
            skinsImages[1].sprite = skinsSprites[skinsSprites.Length - 1];
        }
        else
        {
            skinIndex1 = GetIndexSprite(skinsImages[1]);
            skinsImages[1].sprite = skinsSprites[skinIndex1 - 1];
        }

        if (skinsImages[2].sprite == skinsSprites[0])
        {
            skinsImages[2].sprite = skinsSprites[skinsSprites.Length - 1];
        }
        else
        {
            skinIndex2 = GetIndexSprite(skinsImages[2]);
            skinsImages[2].sprite = skinsSprites[skinIndex2 - 1];
        }
    }
    public void RightSwitch()
    {
        if (skinsImages[0].sprite == skinsSprites[skinsSprites.Length - 1])
        {
            skinsImages[0].sprite = skinsSprites[0];
        }
        else
        {
            skinIndex0 = GetIndexSprite(skinsImages[0]);
            skinsImages[0].sprite = skinsSprites[skinIndex0 + 1];
        }

        if (skinsImages[1].sprite == skinsSprites[skinsSprites.Length - 1])
        {
            skinsImages[1].sprite = skinsSprites[0];
        }
        else
        {
            skinIndex1 = GetIndexSprite(skinsImages[1]);
            skinsImages[1].sprite = skinsSprites[skinIndex1 + 1];
        }

        if (skinsImages[2].sprite == skinsSprites[skinsSprites.Length - 1])
        {
            skinsImages[2].sprite = skinsSprites[0];
        }
        else
        {
            skinIndex2 = GetIndexSprite(skinsImages[2]);
            skinsImages[2].sprite = skinsSprites[skinIndex2 + 1];
        }
    }
    int GetIndexSprite(Image img)
    {
        for (int i = 0; i < skinsSprites.Length; i++)
        {
            if (img.sprite == skinsSprites[i])
            {
                return i;
            }            
        }
        return 0;
    }
}
