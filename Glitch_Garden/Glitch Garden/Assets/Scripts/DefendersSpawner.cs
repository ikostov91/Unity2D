using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendersSpawner : MonoBehaviour
{
    Defender _defender;
    GameObject _defenderParent;

    const string DEFENDER_PARENT_NAME = "Defenders";

    private void Start()
    {
        this.CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        this._defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!this._defenderParent)
        {
            this._defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    private void OnMouseDown()
    {
        if (this._defender is null)
        {
            return;
        }

        var position = this.GetSquareClicked();
        Debug.Log(position);
        this.AttemptToPlaceDefenderAt(position);
    }

    public void SetSelectedDefender(Defender defenderToSelect)
    {
        this._defender = defenderToSelect;
    }

    private void AttemptToPlaceDefenderAt(Vector2 gridPosition)
    {
        var starDisplay = FindObjectOfType<StarDisplay>();
        int defenderCost = this._defender.GetStarCost();

        if (starDisplay.HaveEnoughStars(defenderCost))
        {
            this.SpawnDefender(gridPosition);
            starDisplay.SpendStars(defenderCost);
        }
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(clickPosition);
        Vector2 gridPosition = this.SnapToGrid(worldPosition);
        return gridPosition;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPosition)
    {
        float newX = Mathf.RoundToInt(rawWorldPosition.x);
        float newY = Mathf.RoundToInt(rawWorldPosition.y);

        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 position)
    {
        Defender newDefender = Instantiate(this._defender,
            position,
            Quaternion.identity) as Defender;
        newDefender.transform.parent = this._defenderParent.transform;
    }
}
