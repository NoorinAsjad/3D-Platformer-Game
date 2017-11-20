﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour {
    float maxHealth;
    float health;
    public Image bar;
    public Text numLives;
    bool HealthFinished = false;

    private void Start()
    {
        maxHealth = GameManager.instance.maxHealth;
        health = GameManager.instance.health;
        UpdateHealth(0f);
        UpdateLives();
    }

    public void AssignInitialHealth()
    {
        health = GameManager.instance.maxHealth;
        HealthFinished = false;
    }


    float mapToMaxHealth(float value)
    {
        return value / maxHealth;      
    }

    // Update is called once per frame
    public void UpdateHealth (float amount)
    {
        if (!HealthFinished)
        {
            float newHealth = mapToMaxHealth(health + amount);
            if (newHealth > 1)
            {
                newHealth = 1;
            }
            else if (newHealth < 0)
            {
                newHealth = 0;
            }
            Debug.Log(newHealth);
            bar.fillAmount = newHealth;
            health += amount;
            if (health <= 0)
            {
                HealthFinished = true;
                GameManager.instance.UpdateLives(-1);

            }
        }
    }

    public void UpdateLives ()
    {
        int num = GameManager.instance.lives;
        numLives.text = ""+num;
    }

}
