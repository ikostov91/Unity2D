using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField] float _baseLives = 3;
    [SerializeField] int _damage = 1;
    float _lives = 1;
    Text _livesText;
    LevelLoader _levelLoader;

    // Start is called before the first frame update
    void Start()
    {
        this._levelLoader = FindObjectOfType<LevelLoader>();

        this._lives = this._baseLives - PlayerPrefsController.GetDifficulty();
        this._livesText = this.GetComponent<Text>();
        this.UpdateLivesDisplay();
        Debug.Log("difficulty currently is " + PlayerPrefsController.GetDifficulty());
    }

    private void UpdateLivesDisplay()
    {
        this._livesText.text = this._lives.ToString();
    }

    public void TakeLife()
    {
        this._lives -= this._damage;
        if (this._lives <= 0)
        {
            this._lives = 0;
        }
        this.UpdateLivesDisplay();

        if (this._lives <= 0)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
    }
}
