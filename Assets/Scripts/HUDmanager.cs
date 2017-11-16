using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDmanager : MonoBehaviour {

    public Text score;

	// Use this for initialization
	void Start () {
        UpdateScoresUI();		
	}
	
	public void UpdateScoresUI () {
        score.text = "SCORE: " + GameManager.instance.score.ToString();
	}

}
