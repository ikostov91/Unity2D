using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject _projectile, _gun;
    AttackerSpawner _myLaneSpawner;

    private void Start()
    {
        this.SetLaneSpawner();
    }

    private void Update()
    {
        if (this.IsAttackerInLane())
        {
            Debug.Log("shoot");
            // TODO change animation state to shooting
        }
        else
        {
            Debug.Log("sit and wait");
            // TODO change animation state to idle
        }
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in spawners)
        {
            bool isCloseEnough = 
                (Mathf.Abs(spawner.transform.position.y - this.transform.position.y) <= Mathf.Epsilon);
            if (isCloseEnough)
            {
                this._myLaneSpawner = spawner;
                // return;
            }
        }
    }

    private bool IsAttackerInLane()
    {
        if (this._myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void Fire()
    {
        Instantiate(this._projectile,
            this._gun.transform.position,
            this.transform.rotation);
    }
}
