using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] float _health = 100f;
    [SerializeField] int scoreValue = 150;

    [Header("Shooting")]
    float _shotCounter;
    [SerializeField] float _minTimeBetweenShots = 0.6f;
    [SerializeField] float _maxTimeBetweenShots = 4f;
    [SerializeField] float _projectileSpeed = 5f;

    [Header("Prefabs and Explosion Effects")]
    [SerializeField] GameObject _laserPrefab;
    [SerializeField] GameObject _destroyVFXPrefab;
    [SerializeField] float _durationOfExplosion = 1f;

    [Header("Sound Effects")]
    [SerializeField] AudioClip _deathSFX;
    [SerializeField] [Range(0, 1)] float _deathSoundVolume = 0.7f;
    [SerializeField] AudioClip _shootSound;
    [SerializeField] [Range(0, 1)] float _shootSoundVolume = 0.25f;

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
        AudioSource.PlayClipAtPoint(
                this._shootSound,
                Camera.main.transform.position,
                this._shootSoundVolume);
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
            this.Die();
        }
    }

    private void Die()
    {
        FindObjectOfType<GameSession>().AddToScore(this.scoreValue);
        Destroy(this.gameObject);
        this.TriggerDestroyVFX();
        this.TriggerSoundEffect();
    }

    private void TriggerDestroyVFX()
    {
        GameObject explosion = Instantiate(
                            this._destroyVFXPrefab, 
                            this.gameObject.transform.position,
                            this.gameObject.transform.rotation) as GameObject;
        Destroy(explosion, this._durationOfExplosion);
    }

    private void TriggerSoundEffect()
    {
        AudioSource.PlayClipAtPoint(
            this._deathSFX, 
            Camera.main.transform.position, 
            this._deathSoundVolume);
    }
}
