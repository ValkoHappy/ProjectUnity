using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameOverScreen : Screen
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _startMenuButton;

    public event UnityAction RestartButtonClick;
    public event UnityAction StartMenuButtonClick;

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(OnRestartButton);
        _startMenuButton.onClick.AddListener(OnStartMenuButton);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(OnRestartButton);
        _startMenuButton.onClick.RemoveListener(OnStartMenuButton);
    }

    public void OnRestartButton()
    {
        RestartButtonClick?.Invoke();
    }
    public void OnStartMenuButton()
    {
        StartMenuButtonClick?.Invoke();
    }
}
