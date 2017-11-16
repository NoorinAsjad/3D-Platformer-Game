using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour {
    float maxHealth;
    float health;
    public Image bar;
    public Text numLives;
    bool HealthFinished = false;
    public AudioSource DeathSound;

    private void Start()
    {
        maxHealth = GameManager.instance.maxHealth;
        health = GameManager.instance.health;
        UpdateHealth(0f);
        UpdateLives();
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
            bar.fillAmount = Mathf.Lerp(mapToMaxHealth(health), newHealth, 0.65f);
            health += amount;
            if (health <= 0)
            {
                DeathSound.Play();
                HealthFinished = true;
                Invoke("Death", 2.0f);

            }
        }
    }

    public void UpdateLives ()
    {
        int num = GameManager.instance.lives;
        numLives.text = ""+num;
        Debug.Log(numLives.text);
    }

    void Death()
    {
        GameManager.instance.UpdateLives(-1);
    }

}
