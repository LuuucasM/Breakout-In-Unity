using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void OnPlayButton()
    {
        SceneManager.LoadScene("Level1");
        GameData.PlayerLives = 3;
    }
    public void OnQuitButton()
    {
        Application.Quit();
    }
}
