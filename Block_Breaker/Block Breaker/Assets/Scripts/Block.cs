using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSoundEffect;

    // Cached reference
    Level level;

    void Start()
    {
        this.level = FindObjectOfType<Level>();
        this.level.CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(this.breakSoundEffect, Camera.main.transform.position);
        Destroy(this.gameObject);
        this.level.BlockDestroyed();
    }
}
