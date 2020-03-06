using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    int _numberOfAttackers = 0;
    bool _levelTimerFinished = false;

    public void AttackerSpawned()
    {
        this._numberOfAttackers += 1;
    }

    public void AttackerKilled()
    {
        this._numberOfAttackers -= 1;

        if (this._numberOfAttackers == 0 && this._levelTimerFinished)
        {
            Debug.Log("end level now");
        }
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
