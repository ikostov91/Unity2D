using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalScroll : MonoBehaviour
{
    [Tooltip("Game units per second")]
    [SerializeField] private float _scrollRate = 0.2f;

    // Update is called once per frame
    void Update()
    {
        float x = 0f;
        float y = this._scrollRate * Time.deltaTime;
        Vector2 waterMovement = new Vector2(x, y);

        this.gameObject.transform.Translate(waterMovement);    
    }
}
