using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    //score for collecting the collectibles
    public int score = 0;
    public int lives = 3;
    public int highScore = 0;
    public int currentLevel = 1;
    public static int HIGHESTLEVEL = 1;

    HealthBarController healthbar;
    public float maxHealth = 100f;
    public float health = 100f;

    HUDmanager hudManager;
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            instance.healthbar = FindObjectOfType<HealthBarController>();
            instance.hudManager = FindObjectOfType<HUDmanager>();
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        hudManager = FindObjectOfType<HUDmanager>();
        healthbar = FindObjectOfType<HealthBarController>();
    }

    public void IncreaseScore(int amount)
    {
        score += amount;

        if (hudManager != null)
        {
            hudManager.UpdateScoresUI();
        }
        
        if (score > highScore)
        {
            highScore = score;
        }
    }

    public void DecreaseLives()
    {
        if (lives>0)
            lives--;
        if (hudManager != null)
        {
            hudManager.UpdateLivesUI();
        }
    }

    //resets the game to level 1
    public void ResetGame ()
    {
        score = 0;
        lives = 3;
        currentLevel = 1;
        health = 100f;
        SceneManager.LoadScene("Level 1");
        if (hudManager != null)
        {
            hudManager.UpdateScoresUI();
        }
    }

    public void IncreaseLevel()
    {
        if (currentLevel < HIGHESTLEVEL)
        {
            currentLevel++;
            SceneManager.LoadScene("Level " + currentLevel);
            if (hudManager != null)
            {
                hudManager.UpdateScoresUI();
            }
        } else
        {
            GameOver();
        }
        
    }

    public void GameOver()
    {
        SceneManager.LoadScene("Game Over");
    }

    public void UpdateHealth(float amount)
    {
        Debug.Log("UpdateHealthCalled");
        if (healthbar != null)
        {
            Debug.Log("UpdateHealth of healhbar called");
            healthbar.UpdateHealth(amount);
        }
       
    }


}
