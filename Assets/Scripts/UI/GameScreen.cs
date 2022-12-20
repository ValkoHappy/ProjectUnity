using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameScreen : Screen
{
    [SerializeField] private Button _pauseButton;

    public event UnityAction PauseButtonClick;

    private void OnEnable()
    {
        _pauseButton.onClick.AddListener(OnPauseButton);
    }

    private void OnDisable()
    {
        _pauseButton.onClick.RemoveListener(OnPauseButton);
    }

    public void OnPauseButton()
    {
        PauseButtonClick?.Invoke();
    }
}
