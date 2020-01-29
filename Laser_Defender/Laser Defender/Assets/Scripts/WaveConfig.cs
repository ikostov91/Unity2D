using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpanws = 0.5f;
    [SerializeField] float spawnRandomFactor = 0.3f;
    [SerializeField] int numberOfEnemies = 5;
    [SerializeField] float moveSpeed = 2f;

    public GameObject GetEnemyPrefab()
    {
        return this.enemyPrefab;
    }

    public List<Transform> GetWaypoints()
    {
        List<Transform> waveWaypoints = new List<Transform>();
        foreach (Transform waypoint in this.pathPrefab.transform)
        {
            waveWaypoints.Add(waypoint);
        }

        return waveWaypoints;
    }

    public float GetTimeBetweenSpawns()
    {
        return this.timeBetweenSpanws;
    }

    public float GetSpawnRandomFactor()
    {
        return this.spawnRandomFactor;
    }

    public int GetNumberOfEnemies()
    {
        return this.numberOfEnemies;
    }

    public float GetMoveSpeed()
    {
        return this.moveSpeed;
    }
}
