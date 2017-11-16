using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoorBehavior : MonoBehaviour {
    public GameObject door;
    Animator anim;
    bool open = false;
    bool hasKey = false;
    RaycastHit hit;

    void Start()
    {
        anim = door.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, -Vector3.up, out hit, Mathf.Infinity))
        {
            if (hit.collider.CompareTag("Key"))
            {
                hasKey = true;
            }

            if (hasKey)
            {
                Debug.Log("HasKey");
                if (hit.collider.CompareTag("Player"))
                {
                    if (!open)
                    {
                        open = true;
                        anim.SetBool("open", open);

                        Invoke("HasKeyReset", 5.0f);
                    }
                    else
                    {
                        Invoke("OpenReset", 5.0f);
                        anim.SetBool("open", open);
                    }
                }
            }
        }
    }

    void OpenReset()
    {
        open = false;
    }

    void HasKeyReset ()
    {
        hasKey = false;
    }


}
