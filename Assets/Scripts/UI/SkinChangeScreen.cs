using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SkinChangeScreen : Screen
{
    [SerializeField] private Button _exitButton;

    public event UnityAction ExitButtonClick;

    private void OnEnable()
    {
        _exitButton.onClick.AddListener(OnExitButton);
    }

    private void OnDisable()
    {
        _exitButton.onClick.RemoveListener(OnExitButton);
    }


    public void OnExitButton()
    {
        ExitButtonClick?.Invoke();
    }
}
