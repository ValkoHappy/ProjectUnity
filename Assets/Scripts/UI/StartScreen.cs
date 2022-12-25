using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StartScreen : Screen
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _shopButton;
    [SerializeField] private Button _skinChangeButton;

    public event UnityAction PlayButtonClick;
    public event UnityAction ShopButtonClick;
    public event UnityAction SkinChangeButtonClick;

    private void OnEnable()
    {
        _playButton.onClick.AddListener(OnPlayButton);
        _shopButton.onClick.AddListener(OnShopButton);
        _skinChangeButton.onClick.AddListener(OnSkinChangeButton);
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveListener(OnPlayButton);
        _shopButton.onClick.RemoveListener(OnShopButton);
        _skinChangeButton.onClick.RemoveListener(OnSkinChangeButton);
    }

    public void OnPlayButton()
    {
        PlayButtonClick?.Invoke();
    }
    public void OnShopButton()
    {
        ShopButtonClick?.Invoke();
    }

    public void OnSkinChangeButton()
    {
        SkinChangeButtonClick?.Invoke();
    }
}
