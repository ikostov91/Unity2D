using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int _damage = 100;
    
    public int GetDamage()
    {
        return this._damage;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}
