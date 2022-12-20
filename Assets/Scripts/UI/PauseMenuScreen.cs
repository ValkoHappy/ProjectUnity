using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PauseMenuScreen : Screen
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _startMenuButton;
    [SerializeField] private Button _exitButton;

    public event UnityAction RestartButtonClick;
    public event UnityAction StartMenuButtonClick;
    public event UnityAction ExitButtonClick;

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(OnRestartButton);
        _startMenuButton.onClick.AddListener(OnStartMenuButton);
        _exitButton.onClick.AddListener(OnExitButton);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(OnRestartButton);
        _startMenuButton.onClick.RemoveListener(OnStartMenuButton);
        _exitButton.onClick.RemoveListener(OnExitButton);
    }

    public void OnRestartButton()
    {
        RestartButtonClick?.Invoke();
    }
    public void OnStartMenuButton()
    {
        StartMenuButtonClick?.Invoke();
    }

    public void OnExitButton()
    {
        ExitButtonClick?.Invoke();
    }
}
