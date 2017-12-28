using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSoundBehavior : MonoBehaviour {
    
    public void playDeathSound()
    {
        AudioSource deathSound = GameObject.FindGameObjectWithTag("DeathAudio").GetComponent<AudioSource>();
        deathSound.Play();
    }
}
