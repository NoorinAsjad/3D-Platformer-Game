using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDmanager : MonoBehaviour {

    public Text score;
    public Text information;

    // Use this for initialization
    void Start () {
        UpdateScoresUI();
        UpdateInformativeText("");
	}
	
	public void UpdateScoresUI () {
        score.text = "SCORE: " + GameManager.instance.score.ToString();
	}

    public void UpdateInformativeText(string text)
    {
        information.text = text;
        Invoke("RemoveText", 1.5f);
    }

    void RemoveText()
    {
        information.text = "";
    }

}
