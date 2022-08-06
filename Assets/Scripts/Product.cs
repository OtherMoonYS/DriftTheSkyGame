using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Product : MonoBehaviour
{
    public int price;
    public int skinNum;
    public bool equipped;
    public bool buyed;

    public GameObject lockObj;
    private Image lockObjImage;
    public Sprite lockOpen;
    public Sprite lockClose;

    public GameObject equipBut;
    public Image equipImage;
    public Sprite equipSp;
    public Sprite equippedSp;

    public Sprite skinSp;
    void Start()
    {
        lockObjImage = lockObj.GetComponent<Image>();
        equipImage = equipBut.GetComponent<Image>();
    }

    void Update()
    {
        
    }
}
