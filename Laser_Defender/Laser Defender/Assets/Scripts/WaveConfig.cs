using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] GameObject _pathPrefab;
    [SerializeField] float _timeBetweenSpanws = 0.5f;
    [SerializeField] float _spawnRandomFactor = 0.3f;
    [SerializeField] int _numberOfEnemies = 5;
    [SerializeField] float _moveSpeed = 2f;

    public GameObject GetEnemyPrefab()
    {
        return this._enemyPrefab;
    }

    public List<Transform> GetWaypoints()
    {
        List<Transform> waveWaypoints = new List<Transform>();
        foreach (Transform waypoint in this._pathPrefab.transform)
        {
            waveWaypoints.Add(waypoint);
        }

        return waveWaypoints;
    }

    public float GetTimeBetweenSpawns()
    {
        return this._timeBetweenSpanws;
    }

    public float GetSpawnRandomFactor()
    {
        return this._spawnRandomFactor;
    }

    public int GetNumberOfEnemies()
    {
        return this._numberOfEnemies;
    }

    public float GetMoveSpeed()
    {
        return this._moveSpeed;
    }
}
