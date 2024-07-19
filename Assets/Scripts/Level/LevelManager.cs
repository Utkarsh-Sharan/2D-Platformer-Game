using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private static LevelManager _instance;
    public static LevelManager Instance { get { return _instance; } }

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
