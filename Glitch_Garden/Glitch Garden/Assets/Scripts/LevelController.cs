using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    int _numberOfAttackers = 0;
    bool _levelTimerFinished = false;
    [SerializeField] float _waitToLoad = 4f;
    [SerializeField] float _gameOverDelay = 3f;
    [SerializeField] GameObject _winLabel;
    [SerializeField] GameObject _loseLabel;

    private void Start()
    {
        this._winLabel.SetActive(false);
        this._loseLabel.SetActive(false);
    }

    public void AttackerSpawned()
    {
        this._numberOfAttackers += 1;
    }

    public void AttackerKilled()
    {
        this._numberOfAttackers -= 1;

        if (this._numberOfAttackers == 0 && this._levelTimerFinished)
        {
            this.StartCoroutine(this.HandleWinCondition());
        }
    }

    private IEnumerator HandleWinCondition()
    {
        this._winLabel.SetActive(true);
        this.GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(this._waitToLoad);

        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    public void HandleLoseCondition()
    {
        this._loseLabel.SetActive(true);
        Time.timeScale = 0;
        StartCoroutine(this.EndGame());
    }

    private IEnumerator EndGame()
    {
        yield return new WaitForSeconds(this._gameOverDelay);
        FindObjectOfType<LevelLoader>().GameOver();
    }

    public void LevelTimeFinished()
    {
        this._levelTimerFinished = true;
        this.StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawners)
        {
            spawner.StopSpawning();
        }
    }
}
