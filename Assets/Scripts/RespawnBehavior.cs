using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnBehavior : MonoBehaviour {
    public int numCheckpoints; // number of checkpoints to be collected in the level
    Vector3[] checkpoints; // array to store checkpoints
    int checkpointsCollected = 0; // the number of checkpoints collected in current level
    public GameObject CameraObject; // the cameraObject that follows the player around
    public AudioSource deathSound;

    void Start() {
        checkpoints = new Vector3[numCheckpoints];
    }

    public void AssignCheckpoints(Vector3 position)
    {
        if (checkpointsCollected < numCheckpoints && checkpointsCollected >= 0)
        {
            checkpoints[checkpointsCollected] = position;
            checkpointsCollected++;
        }

    }

    public void RespawnAtCheckpoint()
    {
        if (checkpointsCollected >= 1 && checkpoints[checkpointsCollected - 1] != Vector3.zero)
        {
            // play sound, wait till the end, and then respawn
            Invoke("Respawn", 0.3f);

        }
        else
        {
            //if no checkpoints, reload
            Invoke("ReloadScene", 0.3f);
            
        }

    }

    void Respawn()
    {
        transform.position = checkpoints[checkpointsCollected - 1];
        CameraObject.transform.position = new Vector3(transform.position.x, transform.position.y + 0.99f, transform.position.z);
        GameManager.instance.AssignInitialHealth();
        GameManager.instance.playDeathSound();
    }

    void ReloadScene()
    {
        GameManager.instance.ReloadScene();
    }
}
