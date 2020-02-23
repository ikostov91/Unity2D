using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f, 5f)]
    float _currentSpeed = 0f;

    void Update()
    {
        this.transform.Translate(Vector2.left * this._currentSpeed * Time.deltaTime);
    }

    public void SetMovementSpeed(float speed)
    {
        this._currentSpeed = speed;
    }
}
