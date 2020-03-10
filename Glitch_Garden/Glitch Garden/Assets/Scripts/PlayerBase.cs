using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    LivesDisplay _livesDisplayComponent;

    void Start()
    {
        this._livesDisplayComponent = FindObjectOfType<LivesDisplay>();    
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        this._livesDisplayComponent.TakeLife();
        Object.Destroy(otherCollider.gameObject);
    }
}
