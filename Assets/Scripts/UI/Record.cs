using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Record : MonoBehaviour
{
    [SerializeField] private PlayerStatistic _playerStatistic;
    [SerializeField] private TMP_Text _record;

    private void OnEnable()
    {
        _record.text = _playerStatistic.Record.ToString();
        _playerStatistic.RecordChanged += OnRecordChanged;
    }

    private void OnDisable()
    {

        _playerStatistic.RecordChanged -= OnRecordChanged;
    }

    private void OnRecordChanged(int record)
    {
        _record.text = record.ToString();
    }
}
