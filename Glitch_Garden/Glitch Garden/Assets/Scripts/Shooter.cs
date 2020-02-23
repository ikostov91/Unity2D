using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject _projectile, _gun;

    public void Fire()
    {
        Instantiate(this._projectile,
            this._gun.transform.position,
            this.transform.rotation);
    }
}
