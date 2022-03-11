using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private const int startDelay = 2;
    private const float spawnInterval = 1f;
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 15;
    private float spawnRangeZ = 10;
    private float spawnPosZ = 20;

    enum SpawnCombinations
    {
        FROM_LEFT = 0,
        FROM_RIGHT = 1,
        FROM_UP = 2
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnAnimal()
    {
        var spawnCombination = Random.Range(0, 3);

        switch(spawnCombination)
        {
            case 0:
                SpawnEnemyFromLeft();
                break;
            case 1:
                SpawnEnemyFromRight();
                break;
            default:
                SpawnEnemyFromTop();
                break;
        }
    }

    private void SpawnEnemyFromRight()
    {
        Vector3 spawnPosition = new Vector3(
            spawnRangeX + 10, 0, Random.Range(-spawnRangeX, spawnRangeZ)
        );

        SpawnEnemy(spawnPosition, 90);
    }

    private void SpawnEnemyFromLeft()
    {
        Vector3 spawnPosition = new Vector3(
            -spawnRangeX - 10, 0, Random.Range(-spawnRangeX, spawnRangeZ)
        );

        SpawnEnemy(spawnPosition, -90);
    }

    private void SpawnEnemyFromTop()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ
        );

        SpawnEnemy(spawnPosition, 0);
    }

    private void SpawnEnemy(Vector3 spawnPosition, float rotation)
    {
        var index = Random.Range(0, animalPrefabs.Length);

        var quartenionRotation = animalPrefabs[index].transform.rotation;

        quartenionRotation *= Quaternion.Euler(new Vector3(0, rotation, 0));

        Instantiate(
            animalPrefabs[index],
            spawnPosition,
            quartenionRotation
        );
    }
}
