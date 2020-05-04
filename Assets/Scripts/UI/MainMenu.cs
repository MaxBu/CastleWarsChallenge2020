using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void ReturnToMainMenu()
    {
        //SceneManager.LoadScene(0); //Main menu
    }

    public void OfflineMode()
    {
        SceneManager.LoadScene("GameScene"); //offline mode
    }

    public void MultiplayerMode()
    {
        SceneManager.LoadScene("Lobby"); //multiplayer mode
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
