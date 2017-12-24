using UnityEngine;
using System.Collections;

public class SpikeAttackTest : MonoBehaviour
{
    public bool xdirection = true, sine = true;
    Vector3 startPos;
    float sinFloat;
    public float buffer = 1f;

    void Start()
    {

        startPos = transform.position;

    }

    void Update()
    {
        if (sine)
        {
            sinFloat = Mathf.Sin(Time.time) / buffer + 0.5f;
        } else
        {
            sinFloat = Mathf.Cos(Time.time) / buffer + 0.5f;
        }
        if (xdirection)
        {
            transform.position = startPos + new Vector3(sinFloat, 0f, 0f);
        }
        else
        {
            transform.position = startPos + new Vector3(0f, 0f, sinFloat);
        }
    }
}
