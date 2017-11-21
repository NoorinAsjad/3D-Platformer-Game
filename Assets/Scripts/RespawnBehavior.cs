using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnBehavior : MonoBehaviour {
    public int numCheckpoints; // number of checkpoints to be collected in the level
    Vector3[] checkpoints; // array to store checkpoints
    int[] scores; // array to store the score at checkpoint
    int checkpointsCollected = 0; // the number of checkpoints collected in current level
    public GameObject CameraObject; // the cameraObject that follows the player around
    public AudioSource deathSound;

    void Start() {
        checkpoints = new Vector3[numCheckpoints];
        scores = new int[numCheckpoints];
    }

    public void AssignCheckpoints(Vector3 position, int score)
    {
        if (checkpointsCollected < numCheckpoints && checkpointsCollected >= 0)
        {
            checkpoints[checkpointsCollected] = position;
            scores[checkpointsCollected] = score;
            checkpointsCollected++;
        }

    }

    public void RespawnAtCheckpoint()
    {
        if (checkpointsCollected >= 1 && checkpoints[checkpointsCollected - 1] != Vector3.zero)
        {
            GameManager.instance.score = scores[checkpointsCollected - 1];
            // play sound, wait till the end, and then respawn
            deathSound.Play();
            Invoke("Respawn", 2.0f);

        }
        else
        {
            deathSound.Play();
            //if no checkpoints, reload
            Invoke("ReloadScene", 2.0f);
            
        }

    }

    void Respawn()
    {
        transform.position = checkpoints[checkpointsCollected - 1];
        CameraObject.transform.position = new Vector3(transform.position.x, transform.position.y + 0.99f, transform.position.z);
        GameManager.instance.AssignInitialHealth();
    }

    void ReloadScene()
    {
        GameManager.instance.ReloadScene();
    }
}
