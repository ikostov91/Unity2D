using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour
{
    // [Seria..] in front of variable means we have this available in the inspector.
    [SerializeField] Text textComponent;
    [SerializeField] State startingState;

    State state;

    // Start is called before the first frame update
    void Start()
    {
        this.state = this.startingState;       
        textComponent.text = this.state.GetStateStory();
    }

    // Update is called once per frame
    void Update()
    {
        this.ManageState();
    }

    private void ManageState()
    {
        State[] nextStates = state.GetNextStates();

        for (int index = 0; index < nextStates.Length; index++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + index))
            {
                this.state = nextStates[index];
            }
        }

        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    this.state = nextStates[0];
        //}
        //else if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    this.state = nextStates[1];
        //}
        //else if (Input.GetKeyDown(KeyCode.Alpha3))
        //{
        //    this.state = nextStates[2];
        //}

        this.textComponent.text = this.state.GetStateStory();
    }
}
