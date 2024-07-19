using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager _instance;
    public static LevelManager Instance { get { return _instance; } }

    [SerializeField] private int[] _levels = new int[5];

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (GetLevelStatus(_levels[0]) == LevelStatus.LOCKED)
        {
            SetLevelStatus(_levels[0], LevelStatus.UNLOCKED);
        }
    }

    public void MarkLevelComplete()
    {
        //setting current scene as completed.
        Scene currentScene = SceneManager.GetActiveScene();
        SetLevelStatus(currentScene.buildIndex, LevelStatus.COMPLETED);

        //unlock next level.
        int currentSceneIndex = Array.FindIndex(_levels, level => level == currentScene.buildIndex);
        int nextSceneIndex = currentSceneIndex + 1;
        if(nextSceneIndex < _levels.Length)
        {
            SetLevelStatus(_levels[nextSceneIndex], LevelStatus.UNLOCKED);

            //load next level.
            SoundManager.Instance.Play(Sounds.LEVEL_COMPLETE);
            SceneManager.LoadScene(nextSceneIndex + 1);
        }
        else if(nextSceneIndex == _levels.Length)
        {
            SoundManager.Instance.PlayMusic(Sounds.GAME_COMPLETE_MUSIC);
            SceneManager.LoadScene(6);
        }
    }

    public LevelStatus GetLevelStatus(int level)
    {
        LevelStatus levelStatus = (LevelStatus)PlayerPrefs.GetInt(level.ToString(), 0);
        return levelStatus;
    }

    public void SetLevelStatus(int level, LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(level.ToString(), (int)levelStatus);
    }
}
