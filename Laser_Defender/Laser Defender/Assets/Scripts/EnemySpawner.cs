using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> _waveConfigs;
    [SerializeField] int _startingWave = 0;
    [SerializeField] bool _looping = true;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            yield return this.StartCoroutine(this.SpawnAllWaves());
        } while (this._looping);
    }

    private IEnumerator SpawnAllWaves()
    {
        for (int waveIndex = this._startingWave; waveIndex < this._waveConfigs.Count; waveIndex++)
        {
            WaveConfig currentWave = this._waveConfigs[waveIndex];
            yield return this.SpawnAllEnemiesInWave(currentWave);
        }
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        int enemyCount = waveConfig.GetNumberOfEnemies();
        for (int i = 0; i < enemyCount; i++)
        {
            GameObject newEnemy = Instantiate(
                waveConfig.GetEnemyPrefab(),
                waveConfig.GetWaypoints()[0].transform.position,
                Quaternion.identity);
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);

            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
    }
}
