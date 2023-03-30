using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    menu, inTheGame, gameOVer
}

public class GameManager : MonoBehaviour
{
    public static GameManager sharedInstance;

    public GameState currentGameState = GameState.menu;
    public Canvas menuCanvas;
    public Canvas gameCanvas;
    public Canvas gameOverCanvas;
    public int collectedCoins = 0;



    private void Awake()
    {
        sharedInstance = this; 
    }
    private void Start()
    {
        currentGameState = GameState.menu;
        menuCanvas.enabled = true;
        gameCanvas.enabled = false;
        gameOverCanvas.enabled = false;

    }
    private void Update()
    {
       /* if(Input.GetButtonDown("s")) {
            if(currentGameState != GameState.inTheGame)
            StartGame();
        }*/
    }
    public void StartGame()
    {
        PlayerController.sharedInstance.StartGame();
        LevelGenerator.sharedInstance.GenerateInitialBlocks();
        ChangeGameState(GameState.inTheGame);
        ViewGame.sharedInstace.UpdateHighScore();
    }

    public void GameOver()
    {
        LevelGenerator.sharedInstance.RemoveAllBlocks();
        ChangeGameState(GameState.gameOVer);
        ViewGameOver.sharedInstace.UpdateUI();
    }
    public void BackToMainMenu()
    {
        ChangeGameState(GameState.menu);
    }
    void ChangeGameState(GameState newGameState)
    {
        if(newGameState == GameState.menu)
        {
            menuCanvas.enabled= true;
            gameCanvas.enabled= false;
            gameOverCanvas.enabled= false;

        }else if(newGameState == GameState.inTheGame)
        {
            menuCanvas.enabled = false;
            gameCanvas.enabled= true;
            gameOverCanvas.enabled= false;
            
        }else if(newGameState == GameState.gameOVer)
        {
            menuCanvas.enabled=false;
            gameCanvas.enabled = false;
            gameOverCanvas.enabled= true;
        }

        currentGameState = newGameState;
    }
    public void CollectCoin()
    {
        collectedCoins++;
        ViewGame.sharedInstace.UpdateCoinsLabel();
    }
}
