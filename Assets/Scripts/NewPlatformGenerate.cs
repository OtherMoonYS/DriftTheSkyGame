using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlatformGenerate : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject platformPrefabWithCoin;

    public Transform point1;
    public Transform point2;
    private Vector2 SpawnPos;
    public float minDelay;
    public float maxDelay;
    private float delayTime;
    void Start()
    {
        GetRandomPosX();        
    }

    void Update()
    {
        if (delayTime <= 0)
        {
            Vector2 spawnPos = new Vector2(SpawnPos.x, point1.position.y);
            Instantiate(platformPrefab, spawnPos, Quaternion.identity);
            GetRandomPosX();
            delayTime = Random.Range(minDelay, maxDelay);
        }
        else
        {
            delayTime -= Time.deltaTime;
        }
    }
    void GetRandomPosX()
    {
        SpawnPos.x = Random.Range(point1.position.x, point2.position.x);        
    }
}
