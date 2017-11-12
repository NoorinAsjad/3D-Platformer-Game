using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunScript : MonoBehaviour {

    float vAxis;
    float hAxis;
    public float runningSpeed;
    public Transform player;
    Rigidbody rb;

	// Use this for initialization
	void Start () {
        player= this.gameObject.transform.GetChild(0);
        rb = player.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        vAxis = Input.GetAxis("Vertical");
        hAxis = Input.GetAxis("Horizontal");
        Vector3 change = new Vector3(-hAxis * runningSpeed * Time.deltaTime, 0, -vAxis * runningSpeed * Time.deltaTime);
        Vector3 newPosition = player.transform.position + change;
        rb.MovePosition(newPosition);
        //if statement checking range of newPosition to prevent camera going out of bounds
        transform.position = transform.position+change;
        if (Input.GetKeyDown("a") || Input.GetKeyDown("left"))
        {
            turnLeft();
        }

        if (Input.GetKeyDown("d") || Input.GetKeyDown("right"))
        {
            turnRight();
        }

        if (Input.GetKeyDown("w") || Input.GetKeyDown("up"))
        {
            turnFront();
        }

        if (Input.GetKeyDown("s") || Input.GetKeyDown("down"))
        {
            turnBack();
        }

        



    }

    void turnLeft()
    {
        rb.rotation = Quaternion.FromToRotation(player.transform.position, Vector3.right);
        // to account for the 180 degree position change
    }

    void turnRight()
    {
        rb.rotation = Quaternion.FromToRotation(player.transform.position, Vector3.left);
        // to account for the 180 degree position change
    }

    void turnFront()
    {
        rb.rotation = Quaternion.FromToRotation(player.transform.position, Vector3.back);
        // to account for the 180 degree position change
    }

    void turnBack()
    {
        rb.rotation = Quaternion.FromToRotation(player.transform.position, Vector3.forward);
        // to account for the 180 degree position change
    }
}
