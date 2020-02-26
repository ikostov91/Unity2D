using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int _starCost = 100;

    public void AddStars(int amount)
    {
        FindObjectOfType<StarDisplay>().AddStars(amount);
    }

    public int GetStarCost()
    {
        return this._starCost;
    }
}
