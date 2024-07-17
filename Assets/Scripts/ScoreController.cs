using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    private TextMeshProUGUI _scoreText;
    private int _score = 0;

    // Start is called before the first frame update
    void Awake()
    {
        _scoreText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        RefreshUI();
    }

    public void IncrementScore(int increment)
    {
        _score += increment;
        RefreshUI();
    }

    private void RefreshUI()
    {
        _scoreText.text = "Score: " + _score.ToString();
    }
}
