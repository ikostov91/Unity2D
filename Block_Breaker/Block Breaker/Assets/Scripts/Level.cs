using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks; // Serialized for debugging purposes

    // Cached reference
    SceneLoader sceneLoader;

    private void Start()
    {
        this.sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void CountBreakableBlocks()
    {
        this.breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        this.breakableBlocks--;
        if (this.breakableBlocks <= 0)
        {
            this.sceneLoader.LoadNextScene();
        }
    }
}
