using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDmanager : MonoBehaviour {

    public Text score;
    public Text lives;

	// Use this for initialization
	void Start () {
        UpdateScoresUI();		
	}
	
	public void UpdateScoresUI () {
        score.text = "SCORE: " + GameManager.instance.score.ToString();
	}

    public void UpdateLivesUI ()
    {
        string lifeString = "";
        for (int i = 0; i < GameManager.instance.lives; i++)
        {
            lifeString = " ❤️";
        }
        lives.text = lifeString;
    }
}
