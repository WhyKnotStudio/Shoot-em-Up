using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_scoreText = null;

    private void Awake()
    {
        this.m_scoreText.text = "0";
    }

    public void SetScoreText(int score)
    {
        string score_string = score.ToString();

        this.m_scoreText.text = score_string;
    }
}
