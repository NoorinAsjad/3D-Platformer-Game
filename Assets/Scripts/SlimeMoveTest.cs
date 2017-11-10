using UnityEngine;
using System.Collections;

public class SlimeMoveTest : MonoBehaviour {
    public float translationBuff = 60;
    public float rotationBuff = 1.5f;

	void Update () {

		transform.Translate (Vector3.forward / translationBuff);
		transform.Rotate (Vector3.up * rotationBuff);
	
	}
}
