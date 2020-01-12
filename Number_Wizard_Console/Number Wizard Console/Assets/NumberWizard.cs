using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour
{
    private int MAX;
    private int MIN;
    private int GUESS;

    // Start is called before the first frame update
    void Start()
    {
        this.StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MIN = GUESS;
            this.NextGuess();
            
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MAX = GUESS;
            this.NextGuess();
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("I am a genius.");
            this.StartGame();
        }
    }

    private void StartGame()
    {
        MAX = 1000;
        MIN = 1;
        GUESS = 500;

        Debug.Log("Welcome to Number wizard, yo");
        Debug.Log("Pick a number.");
        Debug.Log($"Highest number is: {MAX}");
        Debug.Log($"Lowest number is: {MIN}");
        Debug.Log($"Tell me if your number is higher or lower than {GUESS}.");
        Debug.Log("Push Up = Higher, Push Down = Lower, Push Enter = Correct.");

        MAX += 1;
    }

    private void NextGuess()
    {
        GUESS = (MAX + MIN) / 2;
        Debug.Log("Is it higher or lower than..." + GUESS);
    }
}
