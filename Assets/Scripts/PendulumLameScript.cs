using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumLameScript : MonoBehaviour {
    public float rotationSpeed = 2;
    Vector3 axis = new Vector3(0, 0, 1f);
    public Transform transformPos;
    public Transform pendulumButt;
    public float someDistance;

    private void Start()
    {
        pendulumButt.position = transformPos.position;
    }

    void Update()
    {
        
        transform.Rotate(axis, Time.deltaTime * rotationSpeed, Space.Self);
        if (Vector3.Distance(pendulumButt.position,transformPos.position)>=someDistance)
        {
            rotationSpeed *= -1;
        } else if (Vector3.Distance(pendulumButt.position, transformPos.position) <= -someDistance)
        {
            rotationSpeed *= -1;
        }

    }
}
