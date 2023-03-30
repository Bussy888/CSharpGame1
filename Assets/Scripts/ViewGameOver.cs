using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ViewGameOver : MonoBehaviour
{
    public static ViewGameOver sharedInstace;
    public TMP_Text coinsLabel;
    public TMP_Text scoreLabel;

    private void Awake()
    {
        sharedInstace = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void UpdateUI()
    {
        if (GameManager.sharedInstance.currentGameState == GameState.gameOVer)
        {
            coinsLabel.text = GameManager.sharedInstance.collectedCoins.ToString();
            scoreLabel.text = PlayerController.sharedInstance.GetDistance().ToString("f0");

        }

    }
}
