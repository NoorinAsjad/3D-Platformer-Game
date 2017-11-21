using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondBehavior : MonoBehaviour
{
    Animator anim;
    bool open = false;
    bool collectedDiamond = false;
    public GameObject diamond;
    public AudioSource diamondSound;

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
            if (!collectedDiamond)
            {
                Destroy(diamond);
                diamondSound.Play();
                GameManager.instance.UpdateInformativeText("+50!!!");
                GameManager.instance.IncreaseScore(50);
                collectedDiamond = true;

            }
            else
            {
                open = false;
                anim.SetBool("open", open);
            }

        }
    }
}