using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameSession : MonoBehaviour
{
    // Configuration parameters
    [Range(0.1f, 1f)] [SerializeField] float gameSpeed = 0.6f;
    [SerializeField] int pointsPerBlockDestroyed = 83;
    [SerializeField] TextMeshProUGUI scoreText;

    // State variables
    [SerializeField] int currentScore = 0;

    // Singleton pattern
    void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else 
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        this.SetScore();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        this.currentScore += this.pointsPerBlockDestroyed;
        this.SetScore();
    }

    private void SetScore()
    {
        this.scoreText.text = this.currentScore.ToString();
    }

    public void RestartGame()
    {
        Destroy(gameObject);
    }
}
