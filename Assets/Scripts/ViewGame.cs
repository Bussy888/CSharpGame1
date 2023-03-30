using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ViewGame : MonoBehaviour

{
    public static ViewGame sharedInstace;
    public TMP_Text coinsLabel;
    public TMP_Text scoreLabel;
    public TMP_Text highScoreLabel;


    private void Awake()
    {
        sharedInstace = this;
    }
    void Update()
    {
        if(GameManager.sharedInstance.currentGameState == GameState.inTheGame)
        {
            scoreLabel.text = PlayerController.sharedInstance.GetDistance().ToString("f0");

        }
    }
    public void UpdateHighScore()
    {
        if(GameManager.sharedInstance.currentGameState == GameState.inTheGame)
        {

            highScoreLabel.text = PlayerPrefs.GetFloat("highScore", 0).ToString("f0");
        }
    }
    public void UpdateCoinsLabel()
    {
        if (GameManager.sharedInstance.currentGameState == GameState.inTheGame)
        {
            coinsLabel.text = GameManager.sharedInstance.collectedCoins.ToString();

        }
    }
}
