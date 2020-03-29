using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] private int _playerLives = 3;
    [SerializeField] private int _score = 0;

    [SerializeField] Text _livesDisplay;
    [SerializeField] Text _scoreDisplay;

    [SerializeField] private float _resetGameDelay = 3f;

    private void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this._livesDisplay.text = this._playerLives.ToString();
        this._scoreDisplay.text = this._score.ToString();
    }
        
    public void ProcessPlayerDeath()
    {
        if (this._playerLives > 1)
        {
            this.TakeLife();
            this.RestartLevel();
        }
        else
        {
            this.ResetGameSession();
        }
    }

    private void TakeLife()
    {
        this._playerLives--;
        this._livesDisplay.text = this._playerLives.ToString();
    }

    private void RestartLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    private void ResetGameSession()
    {
        StartCoroutine(this.WaitBeforeReset());

        SceneManager.LoadScene(0);
        Destroy(this.gameObject);
    }

    private IEnumerator WaitBeforeReset()
    {
        yield return new WaitForSeconds(this._resetGameDelay);
    }

    public void AddToScore(int scoreToAdd)
    {
        this._score += scoreToAdd;
        this._scoreDisplay.text = this._score.ToString();
    }
}
