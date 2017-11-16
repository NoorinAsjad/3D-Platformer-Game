using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehavior : MonoBehaviour {
    public GameObject door;
    Animator anim;
    bool open = false;
    bool hasKey = false;

    private void Start()
    {
        anim = door.GetComponent<Animator>();
    }

    public GameObject spawnpoint;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            if (!hasKey)
            {
                other.transform.position = spawnpoint.transform.position;
                hasKey = true;
            }
            else
            {
                Destroy(other.gameObject);
                hasKey = false;
                if (!open)
                {
                    open = true;
                    anim.SetBool("open", open);
                    Invoke("OpenReset", 5.0f);
                    
                }
                else
                {
                    
                }
            }
        }
    }

    void OpenReset()
    {
        open = false;
        anim.SetBool("open", open);
    }
}
