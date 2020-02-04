using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public void LoadStartMenu()
    {
        Debug.Log("Load start menu");
        SceneManager.LoadScene("Start Menu");
    }

    public void LoadGame()
    {
        Debug.Log("Load Game");
        SceneManager.LoadScene("Game");
    }

    public void LoadGameOver()
    {
        Debug.Log("Load Game Over");
        SceneManager.LoadScene("Game Over");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
