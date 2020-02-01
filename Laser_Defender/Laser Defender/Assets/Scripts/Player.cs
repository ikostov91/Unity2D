using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Configuration parameters
    [Header("Player")]
    [SerializeField] float _moveSpeed = 10f;
    [SerializeField] float _padding = 1f;
    [SerializeField] int _health = 200;

    [Header("Projectile")]
    [SerializeField] GameObject _laserPrefab;
    [SerializeField] float _projectileSpeed;
    [SerializeField] float _projectiveFiringPeriod;

    Coroutine firingCoroutine;

    float xMin;
    float xMax;
    float yMin;
    float yMax;

    // Start is called before the first frame update
    void Start()
    {
        this.SetProjectileSpeed();
        this.SetUpMoveBoundaries();
    }

    private void SetProjectileSpeed()
    {
        this._projectileSpeed = 20f;
        this._projectiveFiringPeriod = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        this.Move();
        this.Fire();
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            this.firingCoroutine = StartCoroutine(this.FireContinously());
        }

        if (Input.GetButtonUp("Fire1"))
        {
            //StopAllCoroutines();
            StopCoroutine(this.firingCoroutine);
        }
    }

    // Coroutine
    private IEnumerator FireContinously()
    {
        while (true)
        {
            GameObject laser = Instantiate(
                            this._laserPrefab,
                            this.gameObject.transform.position,
                            Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, this._projectileSpeed);
            yield return new WaitForSeconds(this._projectiveFiringPeriod);
        }
    }

    private void Move()
    {
        // This makes it frame rate independant
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * this._moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * this._moveSpeed;

        var newXPos = Mathf.Clamp(this.gameObject.transform.position.x + deltaX, this.xMin, this.xMax);
        var newYPos = Mathf.Clamp(this.gameObject.transform.position.y + deltaY, this.yMin, this.yMax);

        this.gameObject.transform.position = new Vector2(newXPos, newYPos);
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + this._padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - this._padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + this._padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - this._padding;
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
