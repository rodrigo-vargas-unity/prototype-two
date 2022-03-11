using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float minDogSpawnRateInterval = 1;
    private float lastDogSpawedTime;

    void Start()
    {
        lastDogSpawedTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Time.time);

        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > lastDogSpawedTime + minDogSpawnRateInterval)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);

            lastDogSpawedTime = Time.time;
        }
    }
}
