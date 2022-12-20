using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<SkinShopItem> _skin;
    [SerializeField] private Player _player;
    [SerializeField] private Item _template;
    [SerializeField] private Transform _itemContainer;

    private void Start()
    {
        for (int i = 0; i < _skin.Count; i++)
        {
            AddItem(_skin[i]);
        }
    }

    private void AddItem(SkinShopItem skinItem)
    {
        Item item = Instantiate(_template, _itemContainer);
        InitializeItem(item, skinItem);
    }

    private void InitializeItem(Item item, SkinShopItem cakeItem)
    {
        item.SetSkin(cakeItem);
        item.SellButtonClick += OnSellButtonClick;
        item.name = _template.name + (transform.childCount + 1);
    }

    private void OnSellButtonClick(SkinShopItem skinItem, Item item)
    {
        TrySellCake(skinItem, item);
    }

    private void TrySellCake(SkinShopItem skinItem, Item item)
    {
        if (_player.CheckSolvency(skinItem.Price))
        {
            _player.BuySkin(skinItem);
            skinItem.Buy();
            UnsubscribeItem(item);

        }
    }

    private void UnsubscribeItem(Item item)
    {
        item.SellButtonClick -= OnSellButtonClick;
    }
}
