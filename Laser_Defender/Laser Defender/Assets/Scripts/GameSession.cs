using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    int _score = 0;

    private void Awake()
    {
        this.SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        int numberGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numberGameSessions > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public int GetScore()
    {
        return this._score;
    }

    public void AddToScore(int scoreValue)
    {
        this._score += scoreValue;
    }

    public void ResetGame()
    {
        Destroy(this.gameObject);
    }
}
