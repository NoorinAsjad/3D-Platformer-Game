using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour {
    float currCountdownValue;
    public Text Timer;
    // Use this for initialization
    void Start () {
        StartCoroutine(StartCountdown());
    }

    public IEnumerator StartCountdown(float countdownValue = 100f)
    {
        currCountdownValue = countdownValue;
        while (currCountdownValue >= 0)
        {
            Timer.text = currCountdownValue.ToString();
            if (GameManager.instance.time != 0)
            {
                currCountdownValue += GameManager.instance.time;
                
            }

            currCountdownValue-=0.5f;
            if (GameManager.instance.stopwatch)
            {
                yield return new WaitForSecondsRealtime(15f);
                GameManager.instance.stopwatchExecution(false);
            }
            yield return new WaitForSeconds(0.5f);
            if (currCountdownValue == 0)
            {
                GameManager.instance.lives -= 1;
                GameManager.instance.ReloadScene();
            }

        }
    }
}
