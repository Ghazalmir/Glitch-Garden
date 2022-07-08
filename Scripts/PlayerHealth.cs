using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float baseHealth = 3; // used for adjusting difficulty
    [SerializeField] int damage = 1;
    float playerHealth;
    Text playerHealthText;


    // Start is called before the first frame update
    void Start()
    {
        playerHealth = baseHealth - PlayerPrefsController.getMasterDifficulty();
        playerHealthText = GetComponent<Text>();
        updatePlayerHealthDisplay();

    }

    private void updatePlayerHealthDisplay()
    {
        playerHealthText.text = playerHealth.ToString();
    }

    public void LosePlayerHealth()
    {
        
        playerHealth -= damage;
        updatePlayerHealthDisplay();

        if (playerHealth <= 0)
        {
            FindObjectOfType<LevelController>().HandleloseCodition();
        }
        
    }

    
    


}
