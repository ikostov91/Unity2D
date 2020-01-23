using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSoundEffect;
    [SerializeField] GameObject blockSparklesVFX; 

    // Cached reference
    Level level;
    GameSession gameStatus;

    void Start()
    {
        this.level = FindObjectOfType<Level>();
        this.gameStatus = FindObjectOfType<GameSession>();
        this.level.CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.DestroyBlock();
        this.TriggerSparklesVFX();
        this.gameStatus.AddToScore();
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(this.breakSoundEffect, Camera.main.transform.position);
        Destroy(this.gameObject);
        this.level.BlockDestroyed();
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, this.gameObject.transform.position, this.gameObject.transform.rotation);
        Destroy(sparkles, 1f);
    }
}
