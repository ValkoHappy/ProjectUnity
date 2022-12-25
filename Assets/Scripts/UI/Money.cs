using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] private PlayerWallet _playerWallet;
    [SerializeField] private TMP_Text _money;

    private void OnEnable()
    {
        _money.text = _playerWallet.Money.ToString();
        _playerWallet.MoneyChanged += OnMoneyChanged;
    }

    private void OnDisable()
    {
        _playerWallet.MoneyChanged -= OnMoneyChanged;
    }

    private void OnMoneyChanged(int record)
    {
        _money.text = record.ToString();
    }
}
