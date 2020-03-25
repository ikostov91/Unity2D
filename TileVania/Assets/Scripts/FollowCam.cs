using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    private Player _player;

    // Start is called before the first frame update
    void Start()
    {
        this._player = FindObjectOfType<Player>();    
    }

    // Update is called once per frame
    void Update()
    {
        float x = this._player.transform.position.x;
        float y = this._player.transform.position.y;

        this.transform.position = new Vector3(x, y, this.transform.position.z);
    }
}
