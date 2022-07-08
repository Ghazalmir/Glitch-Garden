using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    [SerializeField] float waitToLoad = 3f;
    int numberOfAttckers = 0;
    bool levelTimerFinished = false;

    // Start is called before the first frame update
    private void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);

    }

    public void AttackerSpawned()
    {
        numberOfAttckers ++;
    }

    public void AttackerKilled()
    {
        numberOfAttckers --;
        if (numberOfAttckers <= 0 && levelTimerFinished)
        {
            StartCoroutine(HandleWinCodition());
        }
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }

    IEnumerator HandleWinCodition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitToLoad);
        FindObjectOfType<LevelLoader>().LoadNextScene();

    }

    public void HandleloseCodition()
    {
        loseLabel.SetActive(true);
        Time.timeScale = 0; //stops the time

    }

}
