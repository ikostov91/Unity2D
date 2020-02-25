using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float _projectileSpeed = 8f;
    [SerializeField] float _damage = 50f;

    void Update()
    {
        this.transform.Translate(Vector2.right * Time.deltaTime * this._projectileSpeed);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var health = otherCollider.GetComponent<Health>();
        var attacker = otherCollider.GetComponent<Attacker>();

        if (attacker && health)
        {
            health.DealDamage(this._damage);
            Destroy(this.gameObject);
        }
    }
}
