using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMoveForward : MonoBehaviour {

    public float translationSpeed = 1;
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.up * Time.deltaTime * translationSpeed);
	}
}
