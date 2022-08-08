using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    private Transform _transform;
    public Image[] skinsImages;
    public Sprite[] skinsSprites;
    private int skinIndex0;
    private int skinIndex1;
    private int skinIndex2;

    public Text priceText;
    public int[] prices;
    private int priceIndex;
    public bool[] buys;
    public bool[] selected;
    private int selectIndex;
    public GameObject buyButton;
    public GameObject selectButton;
    public Animator priceAnim;

    public Text coinsText;
    public int coinCount;

    [Header("Sounds")]
    public GameObject DenegNeHvataet;
    public GameObject UspeshnoKupilSkin;
    public GameObject SkinVibran;

    private void Awake()
    {
        coinCount = PlayerPrefs.GetInt("Coins");
        for(int i = 1; i < buys.Length; i++)
        {
            buys[i] = PlayerPrefs.GetInt("Buy" + i) == 1;
        }
        for (int i = 0; i < selected.Length; i++)
        {
            selected[i] = PlayerPrefs.GetInt("Select" + i) == 1;
        }        
        if (PlayerPrefs.GetInt("Buy1") == 0 && PlayerPrefs.GetInt("Buy2") == 0 && PlayerPrefs.GetInt("Buy3") == 0 && PlayerPrefs.GetInt("Buy4") == 0 && PlayerPrefs.GetInt("Buy5") == 0)
        {
            Select();
        }
        LeftSwitch();
        RightSwitch();
    }
    private void Start()
    {
        coinsText.text = coinCount.ToString();

        priceAnim = priceText.GetComponent<Animator>();
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ZeroOut();
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            coinCount = 0;
            PlayerPrefs.SetInt("Coins", coinCount);
            coinsText.text = coinCount.ToString();
        }
        else if (Input.GetKey(KeyCode.X))
        {
            coinCount += 1;
            PlayerPrefs.SetInt("Coins", coinCount);
            coinsText.text = coinCount.ToString();
        }
    }

    public void LeftSwitch()
    {
        if (skinsImages[0].sprite == skinsSprites[0])
        {
            skinsImages[0].sprite = skinsSprites[skinsSprites.Length - 1];
            if (!buys[skinsSprites.Length - 1])
            {
                priceText.text = prices[prices.Length - 1].ToString();
                buyButton.SetActive(true);
                selectButton.SetActive(false);
            }
            else
            {
                if (selected[skinsSprites.Length - 1])
                    priceText.text = "Выбрано";
                else
                    priceText.text = "Выбрать";
                buyButton.SetActive(false);
                selectButton.SetActive(true);
            }
        }
        else
        {
            skinIndex0 = GetIndexSprite(skinsImages[0]);
            skinsImages[0].sprite = skinsSprites[skinIndex0 - 1];
            if (!buys[skinIndex0 - 1])
            {
                priceText.text = prices[skinIndex0 - 1].ToString();
                buyButton.SetActive(true);
                selectButton.SetActive(false);
            }
            else
            {
                if (selected[skinIndex0 - 1])
                    priceText.text = "Выбрано";
                else
                    priceText.text = "Выбрать";
                buyButton.SetActive(false);
                selectButton.SetActive(true);
            }
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
            if (!buys[0])
            {
                priceText.text = prices[0].ToString();
                buyButton.SetActive(true);
                selectButton.SetActive(false);
            }
            else
            {
                if (selected[0])
                    priceText.text = "Выбрано";
                else
                    priceText.text = "Выбрать";
                buyButton.SetActive(false);
                selectButton.SetActive(true);
            }
        }
        else
        {
            skinIndex0 = GetIndexSprite(skinsImages[0]);
            skinsImages[0].sprite = skinsSprites[skinIndex0 + 1];
            if (!buys[skinIndex0 + 1])
            {
                priceText.text = prices[skinIndex0 + 1].ToString();
                buyButton.SetActive(true);
                selectButton.SetActive(false);
            }
            else
            {
                if (selected[skinIndex0 + 1])
                    priceText.text = "Выбрано";
                else
                    priceText.text = "Выбрать";
                buyButton.SetActive(false);
                selectButton.SetActive(true);
            }
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
    public void Buy()
    {
        priceIndex = GetIndexSprite(skinsImages[0]);
        if (coinCount > prices[priceIndex])
        {
            coinCount -= prices[priceIndex];
            PlayerPrefs.SetInt("Coins", coinCount);
            buys[priceIndex] = true;
            PlayerPrefs.SetInt("Buy" + priceIndex, 1);
            Select();
            buyButton.SetActive(false);
            selectButton.SetActive(true);
            Instantiate(UspeshnoKupilSkin, _transform.position, Quaternion.identity);
            coinsText.text = coinCount.ToString();
        }
        else
        {
            Instantiate(DenegNeHvataet, _transform.position, Quaternion.identity);
            priceAnim.SetTrigger("DenegNeHvataet");
        }
    }
    public void Select()
    {
        selectIndex = GetIndexSprite(skinsImages[0]);
        if (!selected[selectIndex])
        {
            selected[selectIndex] = true;
            PlayerPrefs.SetInt("Select" + selectIndex, 1);
            priceText.text = "Выбрано";
            for (int i = 0; i < selected.Length; i++)
            {
                if (i == selectIndex)
                {
                    continue;
                }
                else
                {
                    selected[i] = false;
                    PlayerPrefs.SetInt("Select" + i, 0);
                }
            }
            Instantiate(SkinVibran, _transform.position, Quaternion.identity);
        }
    }
    void ZeroOut()
    {
        for (int i = 1; i < buys.Length; i++)
        {
            PlayerPrefs.SetInt("Buy" + i, 0);
        }
        for (int i = 0; i < selected.Length; i++)
        {
            PlayerPrefs.SetInt("Select" + i, 0);
        }        
    }
}
