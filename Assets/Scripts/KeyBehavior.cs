using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBehavior : MonoBehaviour {
    public GameObject lockedDoor, door;
    Animator anim;
    public AudioSource keyCollectionSound;
    bool open = false;
    bool hasKey = false;
    public GameObject keySpawnpoint;

    private void Start()
    {
        anim = lockedDoor.GetComponent<Animator>();

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            if (!hasKey)
            {
                keyCollectionSound.Play();
                GameManager.instance.UpdateInformativeText("Key Collected!");
                other.transform.position = keySpawnpoint.transform.position;
                hasKey = true;
                if (keySpawnpoint.transform.childCount!=0)
                {
                    Destroy(keySpawnpoint.transform.GetChild(0).gameObject);
                }
            }
            else
            {
                Destroy(other.gameObject);
                hasKey = false;
                if (!open)
                {
                    open = true;
                    anim.SetBool("open", open);
                    
                }
            }
        }
    }
}
