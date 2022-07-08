using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] float defaultVolume = 0.8f;

    [SerializeField] Slider difficultySlider;
    [SerializeField] float defaultDifficulty = 0f;


    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = PlayerPrefsController.getMasterVolume();
        difficultySlider.value = PlayerPrefsController.getMasterDifficulty();

    }

    // Update is called once per frame
    void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer)
        {
            musicPlayer.setVolume(volumeSlider.value);
        }
        else
        {
            Debug.LogWarning("No Music Player Found");
        }
        
    }

    public void saveAndExit()
    {
        PlayerPrefsController.setMasterVolume(volumeSlider.value);
        PlayerPrefsController.setDifficulty(difficultySlider.value);
        FindObjectOfType<LevelLoader>().LoadMainMenu();
    }

    public void setDefaults()
    {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
    }
}
