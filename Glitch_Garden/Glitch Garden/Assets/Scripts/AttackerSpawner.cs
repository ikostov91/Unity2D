using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    bool _spawn = true;
    [SerializeField] float _minSpawnDelay = 1f;
    [SerializeField] float _maxSpawnDelay = 5f;

    [SerializeField] Attacker[] _attackerPrefabArray;

    IEnumerator Start()
    {
        while (this._spawn)
        {
            Debug.Log("spawn attacker: " + this._spawn);
            float spawnDelay = Random.Range(this._minSpawnDelay, this._maxSpawnDelay);
            yield return new WaitForSeconds(spawnDelay);

            this.SpawnAttacker();
        }
    }

    public void StopSpawning()
    {
        this._spawn = false;
    }

    private void SpawnAttacker()
    {
        int attackerIndex = Random.Range(0, this._attackerPrefabArray.Length);
        Attacker newAttacker = this._attackerPrefabArray[attackerIndex];
        this.Spawn(newAttacker);
    }

    private void Spawn(Attacker attacker)
    {
        Attacker newAttacker = Instantiate(attacker,
            this.transform.position,
            this.transform.rotation);
        newAttacker.transform.parent = this.transform;
    }
}
