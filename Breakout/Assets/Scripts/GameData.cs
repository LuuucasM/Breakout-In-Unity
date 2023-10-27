using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameData : MonoBehaviour
{
    public static int PlayerLives = 3;
    public static string CurrentScene;
    public static int NumBlocks = 0;
    public void Awake()
    {
        CurrentScene = SceneManager.GetActiveScene().name;
    }
    public static void OnLivesChange()
    {
        if(PlayerLives == 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            ResetBall();
        }
    }
    static void ResetBall()
    {
        GameObject ballobj = GameObject.Find("Ball");
        GameObject paddleobj = GameObject.Find("Paddle");
        ballobj.transform.position = paddleobj.transform.position + (Vector3.up * 0.58f);
        BallScript ballscript = ballobj.GetComponent<BallScript>();
        ballscript.current_velocity = Vector3.zero;
        ballscript.IsStuck = true;
    }
    public static void CheckLevelClear()
    {
        if (NumBlocks == 0)
        {
            if (SceneManager.GetActiveScene().name == "Level1")
            {
                SceneManager.LoadScene("Level2");
            }
            else if (SceneManager.GetActiveScene().name == "Level2")
            {
                SceneManager.LoadScene("Level3");
            }
            else if (SceneManager.GetActiveScene().name == "Level3")
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}
