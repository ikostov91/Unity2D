using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour
{
    private readonly int MAX = 1000;
    private readonly int MIN = 1;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Welcome to Number wizard, yo");
        Debug.Log("Pick a number.");
        Debug.Log($"Highest number is: {MAX}");
        Debug.Log($"Lowest number is: {MIN}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
