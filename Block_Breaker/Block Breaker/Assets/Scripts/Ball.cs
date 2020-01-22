using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Configuration Parameters
    [SerializeField] Paddle paddle;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 2f;
    [SerializeField] AudioClip[] ballSounds;  

    // State
    Vector2 paddleToBallVector;
    private bool hasStarted;

    // Cached component references
    AudioSource myAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        this.paddleToBallVector = this.transform.position - this.paddle.transform.position;
        this.hasStarted = false;
        this.myAudioSource = GetComponent<AudioSource>();
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
        this.transform.position = paddlePosition + paddleToBallVector;
    }

    private void LaunchBallOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
            this.hasStarted = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.hasStarted)
        {
            AudioClip clip = this.ballSounds[UnityEngine.Random.Range(0, this.ballSounds.Length)];
            this.myAudioSource.PlayOneShot(clip);
        }
    }
}
