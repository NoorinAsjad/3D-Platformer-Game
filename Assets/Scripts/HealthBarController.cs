using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour {
    float maxHealth;
    float health;
    public Image bar;

    private void Start()
    {
        maxHealth = GameManager.instance.maxHealth;
        health = GameManager.instance.health;
        UpdateHealth(0f);
    }

    float mapToMaxHealth(float value)
    {
        return value / maxHealth;      
    }

    // Update is called once per frame
    public void UpdateHealth (float amount)
    {
        
        float newHealth = mapToMaxHealth(health+amount);
        Debug.Log(newHealth);
        bar.fillAmount = Mathf.Lerp(mapToMaxHealth(health), newHealth, Time.deltaTime*5);
        health += amount;
    }
}
