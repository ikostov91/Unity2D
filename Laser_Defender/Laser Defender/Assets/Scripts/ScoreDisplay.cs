using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    Text _scoreText;
    GameSession _gameSession;

    // Start is called before the first frame update
    void Start()
    {
        this._scoreText = this.GetComponent<Text>();
        this._gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        this._scoreText.text = this._gameSession.GetScore().ToString();
    }
}
