using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    Text _healthText;
    Player _player; 

    // Start is called before the first frame update
    void Start()
    {
        this._healthText = this.GetComponent<Text>();
        this._player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        this._healthText.text = this._player.GetHealth().ToString();
    }
}
