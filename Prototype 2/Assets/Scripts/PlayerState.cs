using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public int playerLives;
    public int playerScore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseScore()
    {
        playerScore++;

        Debug.Log($"Player Score: {playerScore}");
    }

    public void RemoveLive()
    {
        playerLives--;

        Debug.Log($"Player lives: {playerLives}");

        if (playerLives <= 0)
        {
            Destroy(gameObject);
            Debug.LogError("Game Over!");
        }
    }
}
