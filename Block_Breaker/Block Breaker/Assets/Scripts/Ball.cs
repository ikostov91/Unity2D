using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Configuration Parameters
    [SerializeField] Paddle paddle;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;

    // State
    Vector2 paddleToBallVector;
    private bool hasStarted;

    // Start is called before the first frame update
    void Start()
    {
        this.paddleToBallVector = transform.position - paddle.transform.position;
        this.hasStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!this.hasStarted)
        {
            LockBallToPaddle();
            LaunchBallOnClick();
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePosition = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePosition + paddleToBallVector;
    }

    private void LaunchBallOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
            this.hasStarted = true;
        }
    }
}
