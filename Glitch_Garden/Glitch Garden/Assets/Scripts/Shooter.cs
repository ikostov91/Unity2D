using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject _projectile, _gun;
    AttackerSpawner _myLaneSpawner;
    Animator _animator;

    GameObject _projectileParent;

    const string PROJECTILE_PARENT_NAME = "Projectiles";

    private void Start()
    {
        this.SetLaneSpawner();
        this.SetAnimator();

        this.CreateProjectileParent();
    }

    private void CreateProjectileParent()
    {
        this._projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!this._projectileParent)
        {
            this._projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    private void Update()
    {
        if (this.IsAttackerInLane())
        {
            this._animator.SetBool("IsAttacking", true);
        }
        else
        {
            this._animator.SetBool("IsAttacking", false);
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
            }
        }
    }

    private void SetAnimator()
    {
        this._animator = GetComponent<Animator>();
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
        GameObject newProjectile = Instantiate(this._projectile,
            this._gun.transform.position,
            this.transform.rotation) as GameObject;
        newProjectile.transform.parent = this._projectileParent.transform;
    }
}
