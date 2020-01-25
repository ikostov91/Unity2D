using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    GameSession gameSession;

    private void Start()
    {
        this.gameSession = FindObjectOfType<GameSession>();
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        this.gameSession.RestartGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SelectEasyDifficulty()
    {
        this.gameSession.ChangeDifficulty(0.4f);
        this.LoadNextScene();
    }

    public void SelectMediumDifficulty()
    {
        this.gameSession.ChangeDifficulty(0.6f);
        this.LoadNextScene();
    }

    public void SelectHardDifficulty()
    {
        this.gameSession.ChangeDifficulty(1f);
        this.LoadNextScene();
    }
}
