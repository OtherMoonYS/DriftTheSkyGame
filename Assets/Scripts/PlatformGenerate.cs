using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerate : MonoBehaviour
{
    public GameObject platformPrefab;
      
    private void Update()
    {
        Vector3 SpawnPos = new Vector3();
        for (int i = 0; i < 20; i++)
        {
            SpawnPos.x = Random.Range(-1f, 2f);
            SpawnPos.y += Random.Range(0.5f, 3f);

            Instantiate(platformPrefab, SpawnPos, Quaternion.identity);
        }                                      
    }
}       

