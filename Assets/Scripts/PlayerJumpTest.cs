using UnityEngine;
using System.Collections;

public class PlayerJumpTest : MonoBehaviour
{
	
	Animator anim;
	Rigidbody rb;
	bool jump = false;
    bool run = false;
    float bufferAxisSpeed = 2f;
    float jumpSpeed = 250f;
    public AudioSource coinSound;

	void Start ()
	{
		
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody> ();

    }
    
	void Update ()
	{
        float translation = Input.GetAxis("Vertical") * bufferAxisSpeed;
        float rotation = Input.GetAxis("Horizontal") * bufferAxisSpeed;
        /*bool keysPressed = Input.GetKeyDown("a") || Input.GetKeyDown("d") 
            || Input.GetKeyDown("w") || Input.GetKeyDown("s")
            || Input.GetKeyDown("right") || Input.GetKeyDown("left") 
            || Input.GetKeyDown("up") || Input.GetKeyDown("down");*/

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
                rb.AddForce(Vector3.up * jumpSpeed);
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


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coinSound.Play();
            GameManager.instance.IncreaseScore(10);

        }
        
    }


}
