using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private PlayerStatistic _playerStatistic;
    [SerializeField] private TMP_Text _score;

    private void OnEnable()
    {
        _score.text = _playerStatistic.Score.ToString();
        _playerStatistic.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        _playerStatistic.ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
        _score.text = score.ToString();
    }
}
