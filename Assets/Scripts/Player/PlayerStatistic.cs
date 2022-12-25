using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStatistic : MonoBehaviour
{
    private int _record;
    private int _score;
    private int _previouseScore = 0;

    public int Record => _record;
    public int Score => _score;

    public event UnityAction<int> RecordChanged;
    public event UnityAction<int> ScoreChanged;

    public void RestartScore()
    {
        _score = (int)transform.position.y;
        _previouseScore = _score;
        ScoreChanged?.Invoke(_score);
    }

    public void ChangeScore()
    {
        _score = (int)transform.position.y;
        if (_score > _previouseScore)
        {
            _previouseScore = _score;
            _record = _score;
            ScoreChanged?.Invoke(_score);
            RecordChanged?.Invoke(_record);
        }
    }
}
