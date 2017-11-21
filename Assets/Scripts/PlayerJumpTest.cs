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
    bool jumping = false;
    bool death = false;
    float bufferAxisSpeed = 2f;
    public AudioSource DeathSound;


	void Start ()
	{
		anim = GetComponent<Animator> ();
        character = GetComponent<CharacterController>();

    }
    
	void FixedUpdate ()
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
         // call this function to add an impact force:
    
       


        if (Input.GetKeyDown("space"))
        {
            if (!jump)
            {
                jump = true;
                jumping = true;
                anim.SetBool("jump", true);
                anim.SetBool("land", false);
                AddImpact(Vector3.up,20f);
                Invoke("JumpReset", 0.40f);
                Invoke("OnBeingGrounded", 0.45f);
                Invoke("JumpingReset", 0.70f);
            }
        }

        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit, Mathf.Infinity))
        {
            //Debug.DrawLine(transform.position, hit.point, Color.red);
            if (!jumping && hit.collider.CompareTag("platform"))
            {
                
                transform.position = new Vector3(transform.position.x, hit.point.y, transform.position.z);
            }
            if (!jumping && hit.collider.CompareTag("Ground"))
            {
                if (hit.distance > 0.15f)
                {
                    transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y,hit.point.y, 0.25f), transform.position.z);
                }
            }
            if (!jumping && hit.collider.CompareTag("Death"))
            {
                if (hit.distance > 0.15f)
                {
                    AddImpact(Vector3.down, -20f);
                    if (!death)
                    {
                        GameManager.instance.UpdateHealth(-GameManager.instance.maxHealth);
                        death = true;
                        Invoke("deathReset", 3.5f);
                    }
                }

            }

        }
        
    }

    void deathReset ()
    {
        death = false;
    }

    public void AddImpact(Vector3 dir, float force)
    {
        dir.Normalize();
        if (dir.y < 0) dir.y = -dir.y; // reflect down force on the ground
        impact += dir.normalized * force / mass;
    }

    void OnBeingGrounded()
    {
        anim.SetBool("jump", false);
        anim.SetBool("land", true);

    }

	void JumpReset ()
	{
        
        AddImpact(Vector3.down, -25f);
		jump = false;
	}

    void JumpingReset()
    {
       
        jumping = false;
    }
}
