using UnityEngine;

public class Ball : MonoBehaviour
{
    // Configuration Parameters
    [SerializeField] Paddle paddle;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 2f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;

    // State
    Vector2 paddleToBallVector;
    private bool hasStarted;

    // Cached component references
    AudioSource myAudioSource;
    Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        this.InitializeObjects();
        this.paddleToBallVector = this.transform.position - this.paddle.transform.position;
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

    private void InitializeObjects()
    {
        this.rigidBody = GetComponent<Rigidbody2D>();
        this.myAudioSource = GetComponent<AudioSource>();
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
            this.rigidBody.velocity = new Vector2(xPush, yPush);
            this.hasStarted = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(
            Random.Range(0f, this.randomFactor), 
            Random.Range(0f, this.randomFactor));

        if (this.hasStarted)
        {
            AudioClip clip = this.ballSounds[Random.Range(0, this.ballSounds.Length)];
            this.myAudioSource.PlayOneShot(clip);
            this.rigidBody.velocity += velocityTweak;
        }
    }
}
