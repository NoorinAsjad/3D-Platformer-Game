using UnityEngine;
using System.Collections;

public class PlayerJumpTest : MonoBehaviour
{
    float mass = 3.0F; // defines the character mass
    Vector3 impact = Vector3.zero;
    CharacterController character;
    Animator anim;
	bool jump = false;
    bool run = false;
    float bufferAxisSpeed = 2f;
    float jumpSpeed = 250f;

	void Start ()
	{
		anim = GetComponent<Animator> ();
        character = GetComponent<CharacterController>();

    }
    
	void Update ()
	{
        float translation = Input.GetAxis("Vertical") * bufferAxisSpeed;
        float rotation = Input.GetAxis("Horizontal") * bufferAxisSpeed;

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

        if (impact.magnitude > 0.2F) character.Move(impact * Time.deltaTime);
        // consumes the impact energy each cycle:
        impact = Vector3.Lerp(impact, Vector3.zero, 5 * Time.deltaTime);


        if (Input.GetMouseButtonDown(0))
        {
            if (!jump)
            {
                jump = true;
                anim.SetBool("jump", true);
                anim.SetBool("land", false);
                AddImpact(Vector3.up, 20f);
            }
        }
	}

    // call this function to add an impact force:
    public void AddImpact(Vector3 dir, float force)
    {
        dir.Normalize();
        if (dir.y < 0) dir.y = -dir.y; // reflect down force on the ground
        impact += dir.normalized * force / mass;
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
