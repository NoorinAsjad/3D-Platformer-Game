using UnityEngine;
using System.Collections;

public class PlayerJumpTest : MonoBehaviour
{
	
	Animator anim;
	Rigidbody rb;
	bool jump = false;
    bool run = false;
    float bufferSpeed = 2f;

	void Start ()
	{
		
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody> ();

    }
    
	void Update ()
	{
        float translation = Input.GetAxis("Vertical") * bufferSpeed;
        float rotation = Input.GetAxis("Horizontal") * bufferSpeed;
        bool keysPressed = Input.GetKeyDown("a") || Input.GetKeyDown("d") 
            || Input.GetKeyDown("w") || Input.GetKeyDown("s")
            || Input.GetKeyDown("right") || Input.GetKeyDown("left") 
            || Input.GetKeyDown("up") || Input.GetKeyDown("down");

        if (Mathf.Abs(translation)<0.005f || Mathf.Abs(rotation) < 0.005f)
        {
            run = false;
            anim.SetBool("run", false);
            anim.SetBool("idle", true);
        }

        if (Mathf.Abs(translation)>=0.005f || Mathf.Abs(rotation) >= 0.005f)
        {
            if (!run)
            {
                run = true;
                anim.SetBool("run", true);
                anim.SetBool("idle", false);
            }
            
        }

        
        


        if (Input.GetKeyDown("space"))
        {
            if (!jump)
            {
                jump = true;
                anim.SetBool("jump", true);
                anim.SetBool("land", false);
                rb.AddForce(Vector3.up * 200);
            }
        }
	}

	void OnCollisionEnter ()
	{

		if (jump) {
			Invoke ("JumpReset", 0.25f);
			anim.SetBool ("jump", false);
			anim.SetBool ("land", true);
		}
	}

	void JumpReset ()
	{
		jump = false;
	}

    void RunReset()
    {
        run = false;
    }

   
	
}
