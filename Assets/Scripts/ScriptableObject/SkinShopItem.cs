using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skin", menuName = "Skin Item", order = 51)]
public class SkinShopItem : ScriptableObject
{
    [SerializeField] private Skin _skin;
    [SerializeField] private string _label;
    [SerializeField] private Sprite _icon;
    [SerializeField] private int _price;
    [SerializeField] private bool _isBuy;

    public bool IsBuy => _isBuy;

    public string Label => _label;
    public Skin Skin => _skin;
    public Sprite Icon => _icon;
    public int Price => _price;

    public void Buy()
    {
        _isBuy = true;
    }
}
