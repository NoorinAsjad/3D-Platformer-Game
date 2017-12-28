using UnityEngine;
using System.Collections;

public class PlatformLiftTest : MonoBehaviour
{

	Vector3 startPos;
	float sinFloat;
    public float buffer = 1f;
    public bool sine = true;

	void Start ()
	{

		startPos = transform.position;
	
	}
	
	void Update ()
	{
        if (sine)
        {
            sinFloat = Mathf.Sin(Time.time) / buffer + 0.5f;
        }
        else
        {
            sinFloat = Mathf.Cos(Time.time) / buffer + 0.5f;
        }
		
		transform.position = startPos + new Vector3 (0f, sinFloat, 0f);
	
	}
}
