using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerControllers : MonoBehaviour {
    public AudioSource coinSound, firstAidSound, spikeHitSound, 
        slimeZapSound, lifeIncreasedSound, checkpointSound, diamondSound, levelUpSound;
    RespawnBehavior respawnBehavior;
    int coins;
    

    // Use this for initialization
    void Start () {
        respawnBehavior = FindObjectOfType<RespawnBehavior>();        
	}

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coins++;
            coinSound.Play();
            GameManager.instance.IncreaseScore(10);
            

            if (coins == 6)
            {
                GameManager.instance.IncreaseTimer(3f);
                coins = 0;
                GameManager.instance.UpdateInformativeText("+3s");
                Invoke("cancelTime", 0.55f);
            }
        }

        if (other.CompareTag("Spikes"))
        {
            spikeHitSound.Play();
            GameManager.instance.UpdateHealth(-12f);
        }

        if (other.CompareTag("First Aid"))
        {
            Destroy(other.gameObject);
            firstAidSound.Play();
            GameManager.instance.UpdateInformativeText("Health up!");
            GameManager.instance.UpdateHealth(17f);
        }

        if (other.CompareTag("Slime"))
        {
            slimeZapSound.Play();
            GameManager.instance.UpdateHealth(-10f);
        }

        if (other.CompareTag("Tile"))
        {
            GameManager.instance.UpdateHealth(-20f);
            slimeZapSound.Play();
        }

        if (other.CompareTag("Stopwatch"))
        {
            coinSound.Play();
            GameManager.instance.stopwatchExecution(true);
            Destroy(other.gameObject);
            GameManager.instance.UpdateSecondInformativeText("Timer paused for 15 seconds!");

        }

        if (other.CompareTag("Heart"))
        {
            lifeIncreasedSound.Play();
            Destroy(other.gameObject);
            GameManager.instance.UpdateInformativeText("Lives increased!");
            GameManager.instance.UpdateLives(1);
        }

        if (other.CompareTag("Star"))
        {
            checkpointSound.Play();
            respawnBehavior.AssignCheckpoints(other.gameObject.transform.position);
            GameManager.instance.UpdateInformativeText("Checkpoint!");
            Destroy(other.gameObject);
           
        }

        if (other.CompareTag("Diamond"))
        {
            diamondSound.Play();
            GameManager.instance.UpdateInformativeText("+50!!!");
            GameManager.instance.UpdateSecondInformativeText("+20seconds!!");
            GameManager.instance.IncreaseScore(50);
            Destroy(other.gameObject);
            GameManager.instance.IncreaseTimer(20f);
            Invoke("cancelTime", 0.55f);

        }

        if (other.CompareTag("Box"))
        {
            GameManager.instance.UpdateInformativeText("You need a key to open the locked door!");
            Destroy(other.gameObject);
        }

        if (other.CompareTag("GameOver"))
        {
            levelUpSound.Play();
            Destroy(other.gameObject);
            GameManager.instance.UpdateInformativeText("Level up!!");
            StartCoroutine(Pause(1.49f));
            Invoke("increaseLevel", 0.0167f);
        }


    }

    void increaseLevel()
    {
        GameManager.instance.IncreaseLevel();
    }

    void cancelTime()
    {
        GameManager.instance.IncreaseTimer();
    }
    
    
    private IEnumerator Pause(float p)
    {
        Time.timeScale = 0f;
        float pauseEndTime = Time.realtimeSinceStartup + p;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;
        }
        Time.timeScale = 1;
    }
}
