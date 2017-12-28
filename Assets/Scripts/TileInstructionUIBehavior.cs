using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileInstructionUIBehavior : MonoBehaviour {
    public GameObject panel;

    private void Start()
    {
        panel.SetActive(false);
    }

    void OnTriggerEnter (Collider other) {
        if (other.CompareTag("TileInstruction"))
        {
            if (!panel.activeSelf)
            {
                panel.SetActive(true);
            }
            StartCoroutine(Pause(3f));
            
            
        }
    }

    private IEnumerator Pause(float p)
    {
        Time.timeScale = 0f;
        float pauseEndTime = Time.realtimeSinceStartup + p;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;
        }
        Time.timeScale = 1;
        if (panel.activeSelf)
        {
            panel.SetActive(false);
        }
    }
}
