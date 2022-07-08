using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defenderPrefab;
    GameObject defendersParent;
    const string DEFENDER_PARENT_NAME = "Defenders";
    
    private void Start()
    {
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        defendersParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defendersParent) 
        {
            defendersParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    private void OnMouseDown()
    {
        attemptToPlaceDefender(getSquareClicked());
    }

    private Vector2 getSquareClicked()
    {
        Vector2 clickPos = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = snapToGrid(worldPos);
        return gridPos;
    }

    private Vector2 snapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);

    }

    private void spawnDefender(Vector2 roundedPos)
    {
        Defender newDefender =  Instantiate (defenderPrefab, roundedPos, Quaternion.identity) as Defender;
        newDefender.transform.parent = defendersParent.transform;
    }

    private void attemptToPlaceDefender(Vector2 gridPos)
    {
        var starDisplay = FindObjectOfType<StarsDisplay>();
        if (starDisplay == null) {return;}
        int defenderCost = defenderPrefab.getStarCost();
        if (starDisplay.haveEnoughStars(defenderCost))
        {
            spawnDefender(gridPos);
            starDisplay.spendStars(defenderCost);
        }

    }

    

    public void setSelectedDefender(Defender defenderToSelect)
    {
        defenderPrefab = defenderToSelect;
    }
}
