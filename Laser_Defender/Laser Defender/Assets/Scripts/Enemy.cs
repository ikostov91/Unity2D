using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float _health = 100f;
    [SerializeField] float _shotCounter;
    [SerializeField] float _minTimeBetweenShots = 0.6f;
    [SerializeField] float _maxTimeBetweenShots = 4f;
    [SerializeField] float _projectileSpeed = 5f;
    [SerializeField] GameObject _laserPrefab;

    // Start is called before the first frame update
    void Start()
    {
        this.ResetShotCounter();
    }

    private void ResetShotCounter()
    {
        this._shotCounter = UnityEngine.Random.Range(this._minTimeBetweenShots, this._maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        this.CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {
        this._shotCounter -= Time.deltaTime;
        if (this._shotCounter <= 0f)
        {
            this.Fire();
            this.ResetShotCounter();
        }
    }

    private void Fire()
    {
        GameObject laser = Instantiate(
                            this._laserPrefab,
                            this.gameObject.transform.position,
                            Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -this._projectileSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer)
        {
            return;
        }
        this.ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        this._health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (this._health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
