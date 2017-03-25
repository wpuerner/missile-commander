using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {

    public void startGame()
    {
        Debug.Log("The player started the game");
        Application.LoadLevel("DevScene");
    }
    
    public void quitGame()
    {
        Debug.Log("The player exited the game");
        Application.Quit();
    }

}
