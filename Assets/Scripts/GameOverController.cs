using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public void RestartGame()
    {
        SoundManager.Instance.Play(Sounds.BUTTON_CLICK);
        SoundManager.Instance.PlayMusic(Sounds.MUSIC);
        SceneManager.LoadScene(1);
    }

    public void BackToMenu()
    {
        SoundManager.Instance.Play(Sounds.BUTTON_CLICK);
        SoundManager.Instance.PlayMusic(Sounds.MUSIC);
        SceneManager.LoadScene(0);
    }
}
