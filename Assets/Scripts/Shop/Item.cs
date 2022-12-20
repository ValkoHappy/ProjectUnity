using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _sellButton;

    private SkinShopItem _skinItem;

    public event UnityAction<SkinShopItem, Item> SellButtonClick;

    private void OnEnable()
    {
        _sellButton.onClick.AddListener(OnSellButtonClick);
        _sellButton.onClick.AddListener(CheckCakeState);
    }

    private void OnDisable()
    {
        _sellButton.onClick.RemoveListener(OnSellButtonClick);
        _sellButton.onClick.RemoveListener(CheckCakeState);
    }

    private void OnSellButtonClick()
    {
        SellButtonClick?.Invoke(_skinItem, this);
    }

    private void CheckCakeState()
    {
        if (_skinItem.IsBuy)
        {
            _sellButton.interactable = false;
            _price.text = "Продано!";
        }
    }

    public void SetSkin(SkinShopItem skinItem)
    {
        _skinItem = skinItem;
        RenderSkin(skinItem);
    }

    private void RenderSkin(SkinShopItem skinItem)
    {
        _label.text = skinItem.Label;
        _price.text = skinItem.Price.ToString();
        _icon.sprite = skinItem.Icon;
    }
}
