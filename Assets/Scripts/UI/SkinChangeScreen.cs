using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SkinChangeScreen : Screen
{
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _label;
    [SerializeField] private SkinChange _player;
    [SerializeField] private Button _exitButton;

    public event UnityAction ExitButtonClick;

    private void OnEnable()
    {
        _player.SkinChanged += OnSkinFaseChanged;
        _exitButton.onClick.AddListener(OnExitButton);
    }

    private void OnDisable()
    {
        _player.SkinChanged -= OnSkinFaseChanged;
        _exitButton.onClick.RemoveListener(OnExitButton);
    }

    private void OnSkinFaseChanged(SkinShopItem skinFase)
    {
        _icon.sprite = skinFase.Icon;
        _label.text = skinFase.Label.ToString();
    }

    public void OnExitButton()
    {
        ExitButtonClick?.Invoke();
    }
}
