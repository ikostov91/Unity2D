using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    // Config
    [SerializeField] private float _runSpeed = 5f;
    [SerializeField] private float _jumpSpeed = 50f;

    // State
    private bool _isAlive = true;

    // Cached component references
    private Rigidbody2D _myRigidBody;
    private Animator _myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        this._myRigidBody = GetComponent<Rigidbody2D>();
        this._myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        this.Run();
        this.Jump();
        this.FlipSprite();
    }

    private void Run()
    {
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal"); // -1 to +1
        float x = controlThrow * this._runSpeed;
        float y = this._myRigidBody.velocity.y;

        Vector2 playerVelocity = new Vector2(x, y);
        this._myRigidBody.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(this._myRigidBody.velocity.x) > Mathf.Epsilon;
        this._myAnimator.SetBool("Running", playerHasHorizontalSpeed);
    }

    private void Jump()
    {
        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            Vector2 jumpVelocity = new Vector2(0f, this._jumpSpeed);
            this._myRigidBody.velocity += jumpVelocity;
        }
    }

    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(this._myRigidBody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            // Mathf.Sign returns +1 or -1 depending of the sign of the movement
            this.gameObject.transform.localScale = new Vector2(Mathf.Sign(this._myRigidBody.velocity.x), 1);
        }
    }
}
