﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] float waitToLoad = 4f;
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;

    int numberOfAttackers = 0;
    bool levelTimerFinished = false;
    bool final = false;

    private void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }

    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }

    public void AttackerKilled()
    {
        numberOfAttackers--;
        if(levelTimerFinished)
        {
            //StopSpawners();
            //StartCoroutine(HandleWinCondition());
            FinalWave();
            if(numberOfAttackers >= 10)
            {
                StopSpawners();
                final = true;
            }
            if (numberOfAttackers <= 2 && final)
            {
                StartCoroutine(HandleWinCondition());
            }
        }
    }

    IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitToLoad);
        Time.timeScale = 0;
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    public void HandleLoseCondition()
    {
        loseLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        Time.timeScale = 0;
    }

    public void LevelTimeFinished()
    {
        levelTimerFinished = true;
        //StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawnedArray = FindObjectsOfType<AttackerSpawner>();
        foreach(AttackerSpawner spawner in spawnedArray)
        {
            spawner.StopSpawning();
        }
    }

    private void FinalWave()
    {
        AttackerSpawner[] spawnedArray = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawnedArray)
        {
            spawner.FinalWave();
        }
    }

}
