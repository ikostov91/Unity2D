using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [SerializeField] float _runSpeed = 5f;

    Rigidbody2D _myRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        this._myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        this.Run();
    }

    private void Run()
    {
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal"); // -1 to +1
        float x = controlThrow * this._runSpeed;
        float y = this._myRigidBody.velocity.y;

        Vector2 playerVelocity = new Vector2(x, y);
        this._myRigidBody.velocity = playerVelocity;
    }
}
