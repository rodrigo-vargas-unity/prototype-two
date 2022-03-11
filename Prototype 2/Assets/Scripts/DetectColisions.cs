using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectColisions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        Destroy(other.gameObject);

        if (other.CompareTag("Animal"))
        {
            other.GetComponent<AnimalHunger>().FeedAnimal(1);
        }            

        var player = GameObject.Find("Player");

        if (!player)
            return;

        PlayerState playerState = (PlayerState)player.GetComponent("PlayerState");

        playerState.IncreaseScore();
    }
}
