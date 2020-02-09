using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    Text scoreText;
    GameSession gameSession;

    // Start is called before the first frame update
    void Start()
    {
        this.scoreText = GetComponent<Text>();
        this.gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(this.gameSession.GetScore());
        this.scoreText.text = this.gameSession.GetScore().ToString();
    }
}
