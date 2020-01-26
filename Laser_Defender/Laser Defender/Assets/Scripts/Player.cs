using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Configuration parameters
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 1f;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float projectileSpeed;
    [SerializeField] float projectiveFiringPeriod;

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
        this.projectileSpeed = 20f;
        this.projectiveFiringPeriod = 0.1f;
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
                            this.laserPrefab,
                            this.gameObject.transform.position,
                            Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, this.projectileSpeed);
            yield return new WaitForSeconds(this.projectiveFiringPeriod);
        }
    }

    private void Move()
    {
        // This makes it frame rate independant
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * this.moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * this.moveSpeed;

        var newXPos = Mathf.Clamp(this.gameObject.transform.position.x + deltaX, this.xMin, this.xMax);
        var newYPos = Mathf.Clamp(this.gameObject.transform.position.y + deltaY, this.yMin, this.yMax);

        this.gameObject.transform.position = new Vector2(newXPos, newYPos);
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + this.padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - this.padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + this.padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - this.padding;
    }
}
