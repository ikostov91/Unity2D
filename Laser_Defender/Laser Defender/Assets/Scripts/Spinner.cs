using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] float _speedOfSpin = 1f;
    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Rotate(0, 0, this._speedOfSpin * Time.deltaTime);
    }
}
