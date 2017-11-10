using UnityEngine;
using System.Collections;

public class RotateScript : MonoBehaviour {
    public float rotationSpeed=3;

	void Update () {
	
		transform.Rotate (Vector3.up*rotationSpeed);

	}
}
