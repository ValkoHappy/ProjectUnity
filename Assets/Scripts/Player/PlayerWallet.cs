using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerWallet : MonoBehaviour
{
    [SerializeField] private int _money;

    public event UnityAction<int> MoneyChanged;

    public int Money => _money;

    public void AddCoin()
    {
        _money++;
        MoneyChanged?.Invoke(_money);
    }

    public void WithdrawSkins(int amount)
    {
        _money -= amount;
        MoneyChanged?.Invoke(_money);
    }
}
