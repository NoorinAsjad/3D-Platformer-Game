using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomRotationScript : MonoBehaviour {
    public float rotationSpeed = 2;
    Vector3 axis = new Vector3(0, 0, 1f);

    void Update()
    {

        transform.Rotate(axis,Time.deltaTime*rotationSpeed, Space.Self);

    }
}
