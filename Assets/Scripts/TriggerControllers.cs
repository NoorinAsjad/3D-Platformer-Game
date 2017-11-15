using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerControllers : MonoBehaviour {
    AudioSource coinSound;

    // Use this for initialization
    void Start () {
        coinSound = FindObjectOfType<AudioSource>();
	}

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coinSound.Play();
            GameManager.instance.IncreaseScore(10);

        }

        if (other.CompareTag("GameOver"))
        {
            GameManager.instance.GameOver();
        }

        if (other.CompareTag("Spikes"))
        {
            Debug.Log("Spikes");
            GameManager.instance.UpdateHealth(-15f);
        }

    }

}
