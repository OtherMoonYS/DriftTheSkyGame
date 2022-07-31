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
    public GameObject[] platformBlanks;
    private int randomBlank;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        startPos = _transform.position;

        Instantiate(platformBlanks[randomBlank], spawnPos.position, Quaternion.identity);
        randomBlank = Random.Range(0, platformBlanks.Length);

        Instantiate(platformBlanks[randomBlank], startSpawnPos.position, Quaternion.identity);
        randomBlank = Random.Range(0, platformBlanks.Length);
    }

    void Update()
    {
        float pos = startPos.y + Y; 
        if (_transform.position.y >= pos)
        {
            Instantiate(platformBlanks[randomBlank], spawnPos.position, Quaternion.identity);
            randomBlank = Random.Range(0, platformBlanks.Length);
            startPos = new Vector2(startPos.x, startPos.y + Y);
        }

        if (doodlePos.position.y > _transform.position.y)
        {
            _transform.position = new Vector3(transform.position.x, doodlePos.position.y, transform.position.z); 
        }
    }
    void Restoration()
    {
        randomBlank = Random.Range(0, platformBlanks.Length);
    }    
}
