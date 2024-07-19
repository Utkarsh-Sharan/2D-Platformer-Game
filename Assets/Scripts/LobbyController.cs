using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour
{
    [SerializeField] private GameObject[] _uiElements = new GameObject[4];
    public void PlayGame()
    {
        for (int i = 0; i < 2; i++)
        {
            _uiElements[i].SetActive(false);
        }

        for (int i = 2; i < 4; i++)
        {
            _uiElements[i].SetActive(true);
        }
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
