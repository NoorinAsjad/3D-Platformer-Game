using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInChestBehavior : MonoBehaviour
{
    Animator anim;
    bool open = false;
    bool collectedObject = false;
    public GameObject objectInChest;
    public AudioSource ObjectObtainedSound;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnMouseDown()
    {
        if (!open)
        {

            open = true;
            anim.SetBool("open", open);

        }
        else
        {
            if (!collectedObject)
            {
                if (objectInChest.CompareTag("Diamond"))
                {
                    GameManager.instance.UpdateInformativeText("+50!!!");
                    GameManager.instance.UpdateSecondInformativeText("+20seconds!");
                    Destroy(objectInChest);
                    ObjectObtainedSound.Play();
                    GameManager.instance.IncreaseScore(50);
                    GameManager.instance.IncreaseTimer(20f);
                    Invoke("cancelTime", 0.55f);
                }
                else if (objectInChest.CompareTag("Heart"))
                {
                    GameManager.instance.UpdateLives(1);
                    GameManager.instance.UpdateInformativeText("Life increased!");
                    Destroy(objectInChest);
                    ObjectObtainedSound.Play();
                }



                collectedObject = true;

            }
            else
            {
                open = false;
                anim.SetBool("open", open);
            }

        }
    }

    void cancelTime()
    {
        GameManager.instance.IncreaseTimer();
    }
}