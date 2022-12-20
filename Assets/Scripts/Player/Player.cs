using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMover))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _money;

    private PlayerMover _playerMover;
    private int _record;
    public int _score;
    private int _previouseScore = 0;

    public int Money => _money;
    public int Record => _record;
    public int Score => _score;

    public event UnityAction GameOver;
    public event UnityAction<Skin> SkinBought;

    public event UnityAction<int> RecordChanged;
    public event UnityAction<int> MoneyChanged;
    public event UnityAction<int> ScoreChanged;

    private void Start()
    {
        _playerMover = GetComponent<PlayerMover>();
    }

    private void Update()
    {
        ChangeScore();
    }

    public void ResetPlayer()
    {
        _playerMover.ResetPlayer();
        _score = (int)transform.position.y;
        _previouseScore = _score;
        ScoreChanged?.Invoke(_score);
    }

    public void Die()
    {
        GameOver?.Invoke();
    }

    public void AddCoin()
    {
        _money++;
        MoneyChanged?.Invoke(_money);
    }

    public bool CheckSolvency(int price)
    {
        return _money >= price;
    }

    public void BuySkin(SkinShopItem skinItem)
    {
        WithdrawSkins(skinItem.Price);
        SkinBought?.Invoke(skinItem.Skin);
    }

    private void ChangeScore()
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

    private void WithdrawSkins(int amount)
    {
        _money -= amount;
        MoneyChanged?.Invoke(_money);
    }
}
