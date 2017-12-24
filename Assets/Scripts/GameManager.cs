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

    RespawnBehavior respawner;

    DeathSoundBehavior deathSound;
    AudioSource deathAudio;

    public float time;

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
            instance.respawner = FindObjectOfType<RespawnBehavior>();
            instance.deathSound = FindObjectOfType<DeathSoundBehavior>();
            instance.deathAudio = GameObject.FindGameObjectWithTag("DeathAudio").GetComponent<AudioSource>();
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        hudManager = FindObjectOfType<HUDmanager>();
        healthbar = FindObjectOfType<HealthBarController>();
        respawner = FindObjectOfType<RespawnBehavior>();
        deathSound = FindObjectOfType<DeathSoundBehavior>();
        deathAudio = GameObject.FindGameObjectWithTag("DeathAudio").GetComponent<AudioSource>();
        DontDestroyOnLoad(this.deathAudio);
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

    //Assigns initial health to the HealthBarController when respawner is called
    public void AssignInitialHealth()
    {
        health = maxHealth;
        healthbar.AssignInitialHealth();
        healthbar.UpdateHealth(0);
        
    }

    public float IncreaseTimer(float TimeInSec = 0)
    {
        if (TimeInSec == 0)
        {
            return time = 0;
        }
        else
        {
            return time += TimeInSec;
        }
    }

    public void UpdateInformativeText(string text)
    {
        hudManager.UpdateInformation1Text(text);
    }

    public void UpdateSecondInformativeText(string text)
    {
        hudManager.UpdateInformation2Text(text);
    }

    public void UpdateLives(int num)
    {
        if (lives > 0)
        {
            lives += num;
            if (num < 0)
            {
                //lives decrease, so respawn
                respawner.RespawnAtCheckpoint();
                healthbar.UpdateLives();
                
            }
            else
            {
                //lives increase
                if (healthbar != null)
                {
                    Debug.Log("UpdateLives called");
                    healthbar.UpdateLives();
                }
            }
        }
        else
        {
            GameOver();
        }
        
        
    }

    //resets the game to level 1
    public void ResetGame ()
    {
        score = 0;
        lives = 3;
        currentLevel = 1;
        health = maxHealth;
        SceneManager.LoadScene("Level 1");
        if (hudManager != null)
        {
            hudManager.UpdateScoresUI();
        }
        if (healthbar != null)
        {
            healthbar.UpdateHealth(0);
            healthbar.UpdateLives();
        }
    }

    public void IncreaseLevel()
    {
        if (currentLevel < HIGHESTLEVEL)
        {
            currentLevel++;
            health = maxHealth;
            SceneManager.LoadScene("Level " + currentLevel);
            if (hudManager != null)
            {
                hudManager.UpdateScoresUI();
            }
            if (healthbar != null)
            {
                healthbar.UpdateHealth(0);
                healthbar.UpdateLives();
            }
        } else
        {
            GameOver();
        }
        
    }

    public void playDeathSound()
    {
        deathSound.playDeathSound();
    }

    //reloads the current scene if the lives decrease
    public void ReloadScene()
    {
        health = maxHealth;
        score = 0;
        SceneManager.LoadScene("Level " + currentLevel);
        if (hudManager != null)
        {
            hudManager.UpdateScoresUI();
        }
        if (healthbar != null)
        {
            healthbar.UpdateHealth(0);
            healthbar.UpdateLives();
        }
        if (deathSound != null)
        {
            deathAudio.Play();
        }
    
    }

    public void GameOver()
    {
        SceneManager.LoadScene("Game Over");
    }

    //updates the healthbar UI
    public void UpdateHealth(float amount)
    {
        if (healthbar != null)
        {
            healthbar.UpdateHealth(amount);
        }
    }


}
