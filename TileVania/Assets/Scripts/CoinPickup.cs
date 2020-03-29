using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] private int _coinScore = 100;
    [SerializeField] private AudioClip _coinPickUpSFX;

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        AudioSource.PlayClipAtPoint(this._coinPickUpSFX, Camera.main.transform.position);
        FindObjectOfType<GameSession>().AddToScore(this._coinScore);
        Destroy(gameObject);
    }
}
