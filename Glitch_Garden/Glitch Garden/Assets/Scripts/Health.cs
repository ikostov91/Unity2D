using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float _health = 100f;
    [SerializeField] GameObject _deathVFX;
    
    public void DealDamage(float damage)
    {
        this._health -= damage;

        if (this._health <= 0)
        {
            this.TriggerDeathVFX();
            Destroy(this.gameObject);
        }
    }

    private void TriggerDeathVFX()
    {
        if (!this._deathVFX)
        {
            return;
        }

        GameObject deathVfxObject = Instantiate(this._deathVFX, 
            this.gameObject.transform.position, 
            this.gameObject.transform.rotation);
        Destroy(deathVfxObject, 1f);
    }
}
