using UnityEngine;

public class BlanksSpawn : MonoBehaviour
{
    public Transform spawnPos;
    public Transform startSpawnPos;
    public Transform cameraTrf;
    private Vector2 startPos;
    public float Y;
    public GameObject[] platformEasyBlanks;
    public GameObject[] platformMiddleBlanks;
    public GameObject[] platformHighBlanks;
    public GameObject[] platformStartBlanks;
    private int randomBlank;
    private MeterCounter counter;
    [Header("До какого метра easy, middle and high blanks")]
    public int easyBlanks;
    public int middleBlanks;
    public int highBlanks;

    void Start()
    {
        counter = FindObjectOfType<MeterCounter>();

        startPos = cameraTrf.position;

        randomBlank = Random.Range(0, platformEasyBlanks.Length);
        Instantiate(platformEasyBlanks[randomBlank], spawnPos.position, Quaternion.identity);
        randomBlank = Random.Range(0, platformStartBlanks.Length);

        Instantiate(platformStartBlanks[randomBlank], startSpawnPos.position, Quaternion.identity);
        randomBlank = Random.Range(0, platformEasyBlanks.Length);
    }
    
    void Update()
    {
        float pos = startPos.y + Y;
        if (cameraTrf.position.y >= pos && counter.account < easyBlanks)
        {
            Instantiate(platformEasyBlanks[randomBlank], spawnPos.position, Quaternion.identity);
            randomBlank = Random.Range(0, platformEasyBlanks.Length);
            startPos = new Vector2(startPos.x, startPos.y + Y);
        }
        else if (cameraTrf.position.y >= pos && counter.account < middleBlanks && counter.account > easyBlanks)
        {
            randomBlank = Random.Range(0, platformMiddleBlanks.Length);
            Instantiate(platformMiddleBlanks[randomBlank], spawnPos.position, Quaternion.identity);
            randomBlank = Random.Range(0, platformMiddleBlanks.Length);
            startPos = new Vector2(startPos.x, startPos.y + Y);
        }
        else if (cameraTrf.position.y >= pos && counter.account < highBlanks && counter.account > middleBlanks)
        {
            randomBlank = Random.Range(0, platformHighBlanks.Length);
            Instantiate(platformHighBlanks[randomBlank], spawnPos.position, Quaternion.identity);
            randomBlank = Random.Range(0, platformHighBlanks.Length);
            startPos = new Vector2(startPos.x, startPos.y + Y);
        }
    }
}
