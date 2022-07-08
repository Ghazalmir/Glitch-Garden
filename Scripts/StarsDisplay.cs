using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarsDisplay : MonoBehaviour
{
    [SerializeField] int stars = 100;
    Text starText;

    // Start is called before the first frame update
    void Start()
    {
        starText = GetComponent<Text>();
        updateDisplay();

    }

    

    private void updateDisplay()
    {
        starText.text = stars.ToString();
    }

    public void addStars(int amount)
    {
        stars += amount;
        updateDisplay();
    }

    public void spendStars(int amount)
    {
        if (stars >= amount)
        {
            stars -= amount;
            updateDisplay();
        }
    }

    public bool haveEnoughStars(int amount)
    {
        return stars >= amount;
    }


}
