using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameTimer : MonoBehaviour
{
    [Tooltip("Lavel timer in seconds")]
    [SerializeField] float levelTime = 10f;
    bool triggeredLevelFinished = false;

    void Update()
    {
        if (triggeredLevelFinished) {return;}

        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

        bool timerFinished = (Time.timeSinceLevelLoad >= levelTime);
        if (timerFinished)
        {
            FindObjectOfType<LevelController>().LevelTimerFinished();
            triggeredLevelFinished = true;
        }
    }

    public float getLevelTime()
    {
        return levelTime;
    }

    

}
