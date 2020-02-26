using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] int _stars = 100;
    Text _starText;

    void Start()
    {
        this._starText = GetComponent<Text>();
        this.UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        this._starText.text = this._stars.ToString();
    }

    public bool HaveEnoughStars(int amount)
    {
        return this._stars >= amount;
    }

    public void AddStars(int amount)
    {
        this._stars += amount;
        this.UpdateDisplay();
    }

    public void SpendStars(int amount)
    {
        if (this._stars > amount)
        {
            this._stars -= amount;
            this.UpdateDisplay();
        }
    }
}
