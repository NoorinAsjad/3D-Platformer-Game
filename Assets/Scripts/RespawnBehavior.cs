using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnBehavior : MonoBehaviour {
    public int numCheckpoints;
    Vector3[] checkpoints;
    int[] scores;
    int checkpointsCollected = 0;
    public GameObject PlayerObject;
    public AudioSource deathSound;
	// Use this for initialization
	void Start () {
		checkpoints = new Vector3[numCheckpoints];
        scores = new int[numCheckpoints];
    }
	
    public void AssignCheckpoints(Vector3 position, int score)
    {
        if (checkpointsCollected < numCheckpoints && checkpointsCollected >= 0)
        {
            checkpoints[checkpointsCollected] = position;
            Debug.Log(checkpoints[checkpointsCollected]);
            scores[checkpointsCollected] = score;
            checkpointsCollected++;
        }
        
    }
	
    public void RespawnAtCheckpoint()
    {
        if (checkpointsCollected >= 1 && checkpoints[checkpointsCollected - 1] != Vector3.zero) 
        {
            //Debug.Log(checkpoints[checkpointsCollected - 1]);
            GameManager.instance.score = scores[checkpointsCollected - 1];
            // play sound, wait till the end, and then respawn
            deathSound.Play();
            Invoke("Respawn", 2.0f);

        }
        else
        {
            //if no checkpoints, reload
            GameManager.instance.ReloadScene();
        }

    }

    void Respawn()
    {
        transform.position = checkpoints[checkpointsCollected - 1];
        PlayerObject.transform.position = new Vector3(transform.position.x, transform.position.y + 0.99f, transform.position.z);
        GameManager.instance.AssignInitialHealth();
    }

}
