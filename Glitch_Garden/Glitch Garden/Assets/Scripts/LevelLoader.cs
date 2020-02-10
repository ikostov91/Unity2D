﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] int _loadingDelay = 3;
    int _currentSceneIndex;

    private void Start()
    {
        this._currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (this._currentSceneIndex == 0)
        {
            this.StartCoroutine(this.WaitForTime());
        }
    }

    private IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(this._loadingDelay);
        this.LoadNextScene();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(this._currentSceneIndex + 1);
    }
}
