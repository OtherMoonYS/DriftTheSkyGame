using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform doodlePos;
    private Transform _transform;

    [Header("RandomSpawn")]
    public Transform spawnPos;
    public Transform startSpawnPos;
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

    private void Start()
    {
        _transform = GetComponent<Transform>();
        counter = FindObjectOfType<MeterCounter>();

        startPos = _transform.position;

        randomBlank = Random.Range(0, platformEasyBlanks.Length);
        Instantiate(platformEasyBlanks[randomBlank], spawnPos.position, Quaternion.identity);
        randomBlank = Random.Range(0, platformStartBlanks.Length);

        Instantiate(platformStartBlanks[randomBlank], startSpawnPos.position, Quaternion.identity);
        randomBlank = Random.Range(0, platformEasyBlanks.Length);
    }

    void Update()
    {
        float pos = startPos.y + Y; 
        if (_transform.position.y >= pos && counter.account < easyBlanks)
        {
            Instantiate(platformEasyBlanks[randomBlank], spawnPos.position, Quaternion.identity);
            randomBlank = Random.Range(0, platformEasyBlanks.Length);
            startPos = new Vector2(startPos.x, startPos.y + Y);
        }
        else if (_transform.position.y >= pos && counter.account < middleBlanks && counter.account > easyBlanks)
        {
            randomBlank = Random.Range(0, platformMiddleBlanks.Length);
            Instantiate(platformMiddleBlanks[randomBlank], spawnPos.position, Quaternion.identity);
            randomBlank = Random.Range(0, platformMiddleBlanks.Length);
            startPos = new Vector2(startPos.x, startPos.y + Y);
        }
        else if (_transform.position.y >= pos && counter.account < highBlanks && counter.account > middleBlanks)
        {
            randomBlank = Random.Range(0, platformHighBlanks.Length);
            Instantiate(platformHighBlanks[randomBlank], spawnPos.position, Quaternion.identity);
            randomBlank = Random.Range(0, platformHighBlanks.Length);
            startPos = new Vector2(startPos.x, startPos.y + Y);
        }

        if (doodlePos.position.y > _transform.position.y)
        {
            _transform.position = new Vector3(transform.position.x, doodlePos.position.y, transform.position.z);
        }
    }    
}
