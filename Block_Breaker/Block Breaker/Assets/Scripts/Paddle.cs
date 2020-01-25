using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Configuration Parameters
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float xMinPosition = 1f;
    [SerializeField] float xMaxPosition = 15f;


    // Cached references
    GameSession gameSession;
    Ball ball;

    // Start is called before the first frame update
    void Start()
    {
        this.InitializeObjects();
    }

    private void InitializeObjects()
    {
        this.gameSession = FindObjectOfType<GameSession>();
        this.ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get mouse position relative to the set screen size
        // without having to know if its 1080 width or so on...
        // This gives position as percentage (from 0 to 1)
        // 6 is camera size (half of height)
        // 16 is width (12 height and 4:3 ration => 16)
        Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y);
        paddlePosition.x = Mathf.Clamp(this.GetXPos(), this.xMinPosition, this.xMaxPosition);
        transform.position = paddlePosition;
    }

    private float GetXPos()
    {
        if (this.gameSession.IsAutoPlayEnabled())
        {
            return this.ball.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * this.screenWidthInUnits;
        }
    }
}
