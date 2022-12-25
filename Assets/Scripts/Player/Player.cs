using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMover), typeof(PlayerWallet), typeof(PlayerStatistic))]
public class Player : MonoBehaviour
{
    private PlayerMover _playerMover;
    private PlayerWallet _wallet;
    private PlayerStatistic _playerStatistics;

    public event UnityAction GameOver;
    public event UnityAction<Skin> SkinBought;

    private void Start()
    {
        _playerMover = GetComponent<PlayerMover>();
        _wallet = GetComponent<PlayerWallet>();
        _playerStatistics = GetComponent<PlayerStatistic>();
    }

    private void Update()
    {
        ChangeStatistics();
    }

    public void Restart()
    {
        _playerMover.ResetPlayer();
        _playerStatistics.RestartScore();
    }

    public void Die()
    {
        GameOver?.Invoke();
    }

    public void CollectCoin()
    {
        _wallet.AddCoin();
    }

    public bool CheckSolvency(int price)
    {
        return _wallet.Money >= price;
    }

    public void BuySkin(SkinShopItem skinItem)
    {
        _wallet.WithdrawSkins(skinItem.Price);
        SkinBought?.Invoke(skinItem.Skin);
    }

    private void ChangeStatistics()
    {
        _playerStatistics.ChangeScore();
    }
}
