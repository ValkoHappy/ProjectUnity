using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Record : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _record;

    private void OnEnable()
    {
        _record.text = _player.Record.ToString();
        _player.RecordChanged += OnRecordChanged;
    }

    private void OnDisable()
    {

        _player.RecordChanged -= OnRecordChanged;
    }

    private void OnRecordChanged(int record)
    {
        _record.text = record.ToString();
    }
}
