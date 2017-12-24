using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunScript : MonoBehaviour {

    float vAxis;
    float hAxis;
    public float runningSpeed=2;
    
    Rigidbody rb;
    float cameraRange = 6f;

    bool cursorLockState = true;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        vAxis = Input.GetAxis("Vertical");
        hAxis = Input.GetAxis("Horizontal");
        Vector3 change = new Vector3(-hAxis * runningSpeed * Time.deltaTime, 0, -vAxis * runningSpeed * Time.deltaTime);
        Vector3 newPosition = transform.position + change;
        rb.MovePosition(newPosition);
        
        transform.position = transform.position+change;
        
        if (Input.GetKeyDown("escape"))
        {
            if (cursorLockState)
            {
                Cursor.lockState = CursorLockMode.None;
                cursorLockState = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                cursorLockState = true;
                Cursor.visible = false;
            }
        }
        
    }

    void CameraFollow()
    {
        Vector3 CameraPos = Camera.main.transform.position;
        CameraPos.z = transform.position.z - cameraRange;
        CameraPos.x = transform.position.x - cameraRange;
        Debug.Log(CameraPos);
    }

    void turnLeft()
    {
        rb.rotation = Quaternion.FromToRotation(transform.position, Vector3.right);
        // to account for the 180 degree position change
    }

    void turnRight()
    {
        rb.rotation = Quaternion.FromToRotation(transform.position, Vector3.left);
        // to account for the 180 degree position change
    }

    void turnFront()
    {
        rb.rotation = Quaternion.FromToRotation(transform.position, Vector3.back);
        // to account for the 180 degree position change
    }

    void turnBack()
    {
        rb.rotation = Quaternion.FromToRotation(transform.position, Vector3.forward);
        // to account for the 180 degree position change
    }
}
