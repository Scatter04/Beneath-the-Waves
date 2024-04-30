using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int numberOfBullets = 5;  
    public Vector3 spawnArea; 

    void Start()
    {
        SpawnBullets();
    }

    void SpawnBullets()
    {
        for (int i = 0; i < numberOfBullets; i++)
        {
            Vector3 spawnPosition = new Vector3(
                Random.Range(-spawnArea.x / 2, spawnArea.x / 2),
                0,  // Assuming y is the ground level
                Random.Range(-spawnArea.z / 2, spawnArea.z / 2)
            );
            Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
