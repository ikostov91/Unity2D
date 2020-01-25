using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Configuration parameters
    [SerializeField] AudioClip breakSoundEffect;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprites;

    // Cached reference
    Level level;
    GameSession gameSession;

    SpriteRenderer spriteRenderer;

    // State variable
    [SerializeField] int timesHit; // TODO only serialized for debugging purposes

    void Start()
    {
        this.InitializeObjects();
        this.CountBreakableBlocks();
    }

    private void InitializeObjects()
    {
        this.level = FindObjectOfType<Level>();
        this.gameSession = FindObjectOfType<GameSession>();
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void CountBreakableBlocks()
    {
        if (this.tag == "Breakable")
        {
            this.level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        this.timesHit++;
        int maxHits = this.hitSprites.Length + 1;
        if (this.timesHit >= maxHits)
        {
            this.DestroyBlock();
        }
        else
        {
            this.ShowNextHitSprite();
        }
    }

    private void DestroyBlock()
    {
        this.PlayBlockDestroySFX();
        Destroy(this.gameObject);
        this.level.BlockDestroyed();
        this.TriggerSparklesVFX();
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = this.timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            this.spriteRenderer.sprite = this.hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite is missing from array" + this.gameObject.name);
        }
    }

    private void PlayBlockDestroySFX()
    {
        AudioSource.PlayClipAtPoint(this.breakSoundEffect, Camera.main.transform.position);
        this.gameSession.AddToScore();
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, this.gameObject.transform.position, this.gameObject.transform.rotation);
        Destroy(sparkles, 1f);
    }
}
