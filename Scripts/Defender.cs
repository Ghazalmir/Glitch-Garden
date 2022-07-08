using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int starCost = 100;

    public void addStars (int amount)
    {
        FindObjectOfType<StarsDisplay>().addStars(amount);
    }

    public int getStarCost()
    {
        return starCost;
    }
}
