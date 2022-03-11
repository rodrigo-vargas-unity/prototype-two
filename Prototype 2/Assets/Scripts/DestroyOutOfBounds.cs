using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public PlayerState playerState;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > 50)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < -10 || transform.position.x > 40 || transform.position.x < -40)
        {
            Destroy(gameObject);

            var player = GameObject.Find("Player");

            if (!player)
                return;

            PlayerState playerState = (PlayerState) player.GetComponent("PlayerState");

            playerState.RemoveLive();
        }
    }   
}
