using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    private Button _button;
    [SerializeField] private int _levelNumber;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(_levelNumber);

        switch (levelStatus)
        {
            case LevelStatus.LOCKED:
                Debug.Log("LOCKED!");
                break;

            case LevelStatus.UNLOCKED:
                SoundManager.Instance.Play(Sounds.BUTTON_CLICK);
                SceneManager.LoadScene(_levelNumber);
                break;

            case LevelStatus.COMPLETED:
                SoundManager.Instance.Play(Sounds.BUTTON_CLICK);
                SceneManager.LoadScene(_levelNumber);
                break;
        }
    }
}
