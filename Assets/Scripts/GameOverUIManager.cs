using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUIManager : MonoBehaviour {
    public Text HighScores;
    public Text NoobScore;

    private void Start()
    {
        DisplayScores();
    }

    // Use this for initialization
    public void DisplayScores () {
        int HS = GameManager.instance.highScore;
        string hScores = HS.ToString();
        HighScores.text = hScores;
        NoobScore.text = "YOUR  NOOB  ASS  SCORES  ARE: " + GameManager.instance.score.ToString();
	}

    public void RestartGame()
    {
        GameManager.instance.ResetGame();
    }


}
