using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSceneScript : MonoBehaviour
{
    public void newGame()
    {
        var gameManager = FindObjectOfType<GameManager>();
            if (gameManager)
            {
                gameManager.StartGame();   
            }
    }
    public void LoadMenu()
    {
        var gameManager = FindObjectOfType<GameManager>();
            if (gameManager)
            {
                gameManager.Menu();   
            }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
