using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField] int _lives = 10;
    Text _livesText;
    LevelLoader _levelLoader;
    [SerializeField] float _gameOverDelay = 3f;
    [SerializeField] int _damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        this._levelLoader = FindObjectOfType<LevelLoader>();

        this._livesText = this.GetComponent<Text>();
        this.UpdateLivesDisplay();
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
            this.StartCoroutine(this.EndGame());
        }
    }

    private IEnumerator EndGame()
    {
        yield return new WaitForSeconds(this._gameOverDelay);
        this._levelLoader.GameOver();
    }
}
