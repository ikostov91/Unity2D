using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    bool _spawn = true;
    [SerializeField] float _minSpawnDelay = 1f;
    [SerializeField] float _maxSpawnDelay = 5f;

    [SerializeField] Attacker _attackerPrefab;

    IEnumerator Start()
    {
        while (this._spawn)
        {
            float spawnDelay = UnityEngine.Random.Range(this._minSpawnDelay, this._maxSpawnDelay);
            yield return new WaitForSeconds(spawnDelay);

            this.SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {
        Instantiate(this._attackerPrefab, this.transform.position, this.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
