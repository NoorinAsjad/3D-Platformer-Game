using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDmanager : MonoBehaviour {

    public Text score;
    public Text information1;
    public Text information2;

    // Use this for initialization
    void Start () {
        UpdateScoresUI();
        UpdateInformation1Text("");
        UpdateInformation2Text("");
	}
	
	public void UpdateScoresUI () {
        score.text = "Score " + GameManager.instance.score.ToString();
	}

    public void UpdateInformation1Text(string text)
    {
        information1.text = text;
        Invoke("RemoveTimeText", 1.5f);
    }

    public void UpdateInformation2Text(string text)
    {
        information2.text = text;
        Invoke("RemoveScoreText", 1.5f);
    }

    void RemoveTimeText()
    {
        information1.text = "";
    }

    void RemoveScoreText()
    {
        information2.text = "";
    }

}
