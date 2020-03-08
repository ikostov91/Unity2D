using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f, 5f)]
    float _currentSpeed = 0f;
    GameObject _currentTarget;

    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned(); 
    }

    private void OnDestroy()
    {
        LevelController levelController = FindObjectOfType<LevelController>();
        if (levelController != null)
        {
            levelController.AttackerKilled();
        }
    }

    void Update()
    {
        this.transform.Translate(Vector2.left * this._currentSpeed * Time.deltaTime);
        this.UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (!this._currentTarget)
        {
            GetComponent<Animator>().SetBool("IsAttacking", false);
        }
    }

    public void SetMovementSpeed(float speed)
    {
        this._currentSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("IsAttacking", true);
        this._currentTarget = target;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (!this._currentTarget)
        {
            return;
        }

        Health health = this._currentTarget.GetComponent<Health>();
        if (health)
        {
            health.DealDamage(damage);
        }
    }
}
