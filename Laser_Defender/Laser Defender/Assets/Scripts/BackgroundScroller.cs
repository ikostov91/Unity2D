using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] float _backgroundScrollSpeed = 0.05f;
    Material _myMaterial;
    Vector2 _offSet;

    // Start is called before the first frame update
    void Start()
    {
        this._myMaterial = GetComponent<Renderer>().material;
        this._offSet = new Vector2(0f, this._backgroundScrollSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        this._myMaterial.mainTextureOffset += this._offSet * Time.deltaTime;
    }
}
