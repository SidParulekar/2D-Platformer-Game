using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;

    public static LevelManager Instance { get { return instance; } }

    public string[] Levels;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }

    }

    private void Start()
    {
        if(GetLevelStatus("Level 1") == LevelStatus.Locked)
        {
            SetLevelStatus("Level 1", LevelStatus.Unlocked);
        }
    }

    public void LevelComplete()
    {
       Scene current_scene = SceneManager.GetActiveScene();
       SetLevelStatus(current_scene.name, LevelStatus.Completed);
        if (current_scene.buildIndex < Levels.Length)
        {
            /*int nextSceneIndex = current_scene.buildIndex + 1;
            Scene next_scene = SceneManager.GetSceneByBuildIndex(nextSceneIndex);
            SceneManager.LoadScene(nextSceneIndex);
            SceneManager.SetActiveScene(next_scene);
            SetLevelStatus(next_scene.name, LevelStatus.Unlocked);*/

            int currentSceneIndex = Array.FindIndex(Levels, level => level == current_scene.name);
            int nextSceneIndex = currentSceneIndex + 1;
            SetLevelStatus(Levels[nextSceneIndex], LevelStatus.Unlocked);
            SceneManager.LoadScene(nextSceneIndex + 1);
        }
    }

    public LevelStatus GetLevelStatus(string level) 
    {
       LevelStatus levelStatus = (LevelStatus)PlayerPrefs.GetInt(level,0);
       return levelStatus;
    }

    public void SetLevelStatus(string level, LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(level, (int)levelStatus);
    }
}
