using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1f;

    private Rigidbody2D _myRigidBody;

    private bool _isFacingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        this._myRigidBody = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        
        this.Move();
    }

    private void Move()
    {
        float x = this._moveSpeed;
        float y = 0f;
        Vector2 enemyMovement = new Vector2(x, y);
        this._myRigidBody.velocity = enemyMovement;
    }

    private void OnTriggerExit2D(Collider2D otherCollider)
    {
        this.ChangeMovementDirection();
        this.FlipEnemySprite();
    }

    private void FlipEnemySprite()
    {
        float x = -1 * Mathf.Sign(this._myRigidBody.velocity.x);
        float y = 1f;
        this.gameObject.transform.localScale = new Vector2(x, y);
    }

    private void ChangeMovementDirection()
    {
        this._moveSpeed *= -1f;
    }
}
