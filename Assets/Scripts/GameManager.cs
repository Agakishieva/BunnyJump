using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] platformPrefab;
    [SerializeField] private float platformCount;

    public void Start()
    {
        Vector3 spawnPos = new Vector3();

        for (int i = 0; i < platformCount; i++)
        {
            int numPlatform = Random.Range(0, platformPrefab.Length);
            spawnPos.y += Random.Range(0.5f, 2f);
            spawnPos.x = Random.Range(-2f, 2f);
            Instantiate(platformPrefab[numPlatform], spawnPos, Quaternion.identity);
        }
    }
}
