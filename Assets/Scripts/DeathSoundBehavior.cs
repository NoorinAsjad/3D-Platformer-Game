using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSoundBehavior : MonoBehaviour {
    AudioSource deathSound;

    private void Start()
    {
        deathSound = GameObject.FindGameObjectWithTag("DeathAudio").GetComponent<AudioSource>();
    }
    public void playDeathSound()
    {
        deathSound.Play();
    }
}
