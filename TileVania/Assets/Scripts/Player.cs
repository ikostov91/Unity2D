using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    // Config
    [SerializeField] private float _runSpeed = 5f;
    [SerializeField] private float _jumpSpeed = 50f;
    [SerializeField] private float _climbSpeed = 2f;
    [SerializeField] private Vector2 _deathKick = new Vector2(25f, 25f);

    // State
    private bool _isAlive = true;

    // Cached component references
    private Rigidbody2D _myRigidBody;
    private Animator _myAnimator;
    private CapsuleCollider2D _myBodyCollider2d;
    private BoxCollider2D _myFeetCollider2d;
    private float _gravityScaleAtStart;

    // Start is called before the first frame update
    void Start()
    {
        this._myRigidBody = GetComponent<Rigidbody2D>();
        this._myAnimator = GetComponent<Animator>();
        this._myBodyCollider2d = GetComponent<CapsuleCollider2D>();
        this._myFeetCollider2d = GetComponent<BoxCollider2D>();

        this._gravityScaleAtStart = this._myRigidBody.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (!this._isAlive)
        {
            return; 
        }

        this.Run();
        this.ClimbLadder();
        this.Jump();
        this.FlipSprite();
        this.Die();
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

    private void ClimbLadder()
    {
        int layerMask = LayerMask.GetMask("Climbing");
        if (!this._myFeetCollider2d.IsTouchingLayers(layerMask))
        {
            this._myAnimator.SetBool("Climbing", false);
            this._myRigidBody.gravityScale = this._gravityScaleAtStart;
            return;
        }

        float controlThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float x = this._myRigidBody.velocity.x;
        float y = this._climbSpeed * controlThrow;
        Vector2 climbVelocity = new Vector2(x, y);
        this._myRigidBody.velocity = climbVelocity;

        this._myRigidBody.gravityScale = 0f;

        bool playerHasVerticalVelocity = Mathf.Sign(this._myRigidBody.velocity.y) > Mathf.Epsilon;
        this._myAnimator.SetBool("Climbing", playerHasVerticalVelocity);
    }

    private void Jump()
    {
        int layerMask = LayerMask.GetMask("Ground");
        if (!this._myFeetCollider2d.IsTouchingLayers(layerMask))
        {
            return;
        }

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

    private void Die()
    {
        int layerMask = LayerMask.GetMask("Enemy", "Hazards");
        if (this._myBodyCollider2d.IsTouchingLayers(layerMask))
        {
            this._isAlive = false;
            this._myAnimator.SetTrigger("Dying");
            this._myRigidBody.velocity = this._deathKick;

            FindObjectOfType<GameSession>().ProcessPlayerDeath();
        }
    }
}
