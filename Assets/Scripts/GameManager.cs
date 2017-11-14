using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    //score for collecting the collectibles
    public int score = 0;
    public int lives = 3;
    public int highScore = 0;
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        if (score > highScore)
        {
            highScore = score;
        }
        Debug.Log(score);
    }

}
