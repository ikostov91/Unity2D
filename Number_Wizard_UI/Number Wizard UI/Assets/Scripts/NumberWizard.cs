using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberWizard : MonoBehaviour
{

    [SerializeField] int max;
    [SerializeField] int min;
    [SerializeField] TextMeshProUGUI guessText;

    int guess;

    // Use this for initialization
    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        this.NextGuess();
    }

    public void OnPressHigher()
    {
        this.min = this.guess + 1;
        this.NextGuess();
    }

    public void OnPressLower()
    {
        this.max = this.guess - 1;
        this.NextGuess();
    }

    private void NextGuess()
    {
        this.guess = Random.Range(this.min, this.max + 1);
        this.guessText.text = this.guess.ToString();
    }
}