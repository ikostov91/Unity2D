using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Configuration Parameters
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float xMinPosition = 1f;
    [SerializeField] float xMaxPosition = 15f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get mouse position relative to the set screen size
        // without having to know if its 1080 width or so on...
        // This gives position as percentage (from 0 to 1)
        // 6 is camera size (half of height)
        // 16 is width (12 height and 4:3 ration => 16)
        float mousePosInUnits = Input.mousePosition.x / Screen.width * this.screenWidthInUnits;
        Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y);
        paddlePosition.x = Mathf.Clamp(mousePosInUnits, this.xMinPosition, this.xMaxPosition);
        transform.position = paddlePosition;
    }
}
