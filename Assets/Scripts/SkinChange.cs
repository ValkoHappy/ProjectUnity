using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SkinChange : MonoBehaviour
{
    [SerializeField] private List<Skin> _skinTemplates;
    [SerializeField] private Player _player;

    private int _currentSkinNumber = 0;
    private int _previousSkinNumber = 0;

    private Skin _skin;

    public event UnityAction<SkinShopItem> SkinChanged;

    private void OnEnable()
    {
        _player.SkinBought += OnSkinBought;
    }

    private void OnDisable()
    {
        _player.SkinBought -= OnSkinBought;
    }

    private void Start()
    {
        _player = GetComponent<Player>();
        SetSkin(_skinTemplates[0]);
        _previousSkinNumber = 0;
    }

    private void OnSkinBought(Skin skin)
    {
        _skinTemplates.Add(skin);
        SetSkin(skin);
        TurnOffSkin(skin);
    }

    public void SwitchNextSkin()
    {
        if (_currentSkinNumber == _skinTemplates.Count - 1)
            _currentSkinNumber = 0;
        else
            _currentSkinNumber++;

        if (_currentSkinNumber != _previousSkinNumber)
            _previousSkinNumber = _currentSkinNumber;

        ChangeSkin(_skinTemplates[_currentSkinNumber]);
    }

    public void SwitchPreviousSkin()
    {
        if (_currentSkinNumber == 0)
            _currentSkinNumber = _skinTemplates.Count - 1;
        else
            _currentSkinNumber--;

        if(_currentSkinNumber != _previousSkinNumber)
           _previousSkinNumber = _currentSkinNumber;

        ChangeSkin(_skinTemplates[_currentSkinNumber]);
    }

    private void EnableSkin(Skin skin)
    {
        for (int i = 0; i < _skinTemplates.Count; i++)
        {
            if (_skinTemplates[i] == skin)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }

    private void TurnOffSkin(Skin skin)
    {
        for (int i = 0; i < _skinTemplates.Count; i++)
        {
            if (_skinTemplates[i] == skin)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    private void SetSkin(Skin skin)
    {
        Instantiate(skin, transform);
        EnableSkin(skin);
    }

    private void ChangeSkin(Skin skin)
    {
        for(int i = 0; i < _skinTemplates.Count; i++) 
        {
            if (_skinTemplates[i] == skin)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
