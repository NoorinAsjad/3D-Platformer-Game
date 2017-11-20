using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerControllers : MonoBehaviour {
    public AudioSource coinSound, firstAidSound, spikeHitSound, slimeZapSound, lifeIncreasedSound;
    RespawnBehavior respawnBehavior;

    // Use this for initialization
    void Start () {
        respawnBehavior = FindObjectOfType<RespawnBehavior>();        
	}

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coinSound.Play();
            GameManager.instance.IncreaseScore(10);

        }

        if (other.CompareTag("Spikes"))
        {
            spikeHitSound.Play();
            GameManager.instance.UpdateHealth(-25f);
        }

        if (other.CompareTag("First Aid"))
        {
            Destroy(other.gameObject);
            firstAidSound.Play();
            GameManager.instance.UpdateHealth(10f);
        }

        if (other.CompareTag("Slime"))
        {
            slimeZapSound.Play();
            GameManager.instance.UpdateHealth(-5f);
        }

        if (other.CompareTag("Heart"))
        {
            lifeIncreasedSound.Play();
            Destroy(other.gameObject);
            GameManager.instance.UpdateLives(1);
        }

        if (other.CompareTag("Star"))
        {
            int score = GameManager.instance.score;
            respawnBehavior.AssignCheckpoints(other.gameObject.transform.position, score);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("GameOver"))
        {
            Debug.Log("Gameover touched");
            respawnBehavior.RespawnAtCheckpoint();
        }

    }

}
