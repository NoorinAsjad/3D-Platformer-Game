﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public Transform playerCam, character, centerPoint;

    private float mouseX, mouseY;
    public float mouseSensitivity = 10f;
    public float mouseYPosition = 1f;

    private float moveFB, moveLR;
    public float moveSpeed = 2f;

    private float zoom;
    public float zoomSpeed = 2;

    public float zoomMin = -1f;
    public float zoomMax = -3f;

    public float rotationSpeed = 30f;



    // Use this for initialization
    void Start()
    {

        zoom = -1.2f;
        //playerCam.transform.localPosition = new Vector3(0, 0, zoom);
        centerPoint.localRotation = Quaternion.Euler(0, 180, 0);

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        zoom += Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;

        if (zoom > zoomMin)
            zoom = zoomMin;

        if (zoom < zoomMax)
            zoom = zoomMax;

        playerCam.transform.localPosition = new Vector3(0, 0, zoom);

        //if (Input.GetMouseButton(1))
            mouseX += Input.GetAxisRaw("Mouse X");
            mouseY -= Input.GetAxisRaw("Mouse Y");
            

        mouseY = Mathf.Clamp(mouseY, -60f, 60f);
        playerCam.LookAt(centerPoint);
        centerPoint.localRotation = Quaternion.Euler(mouseY, mouseX, 0);

        moveFB = Input.GetAxisRaw("Vertical") * moveSpeed;
        moveLR = Input.GetAxisRaw("Horizontal") * moveSpeed;

        Vector3 movement = new Vector3(moveLR, 0f, moveFB);
        movement = character.rotation * movement;
        character.GetComponent<CharacterController>().Move(movement * Time.deltaTime);
        centerPoint.position = new Vector3(character.position.x, character.position.y + mouseYPosition, character.position.z);

        if (Input.GetAxis("Vertical") != 0)
        {

            Quaternion turnAngle = Quaternion.Euler(0, centerPoint.eulerAngles.y, 0);

            character.rotation = Quaternion.Slerp(character.rotation, turnAngle, Time.deltaTime * rotationSpeed);

        }

    }
   
}
