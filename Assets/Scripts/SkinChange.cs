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
    }

    public void NextSkinFase()
    {
        RemoveSkin(_skinTemplates[_currentSkinNumber]);

        if (_currentSkinNumber == _skinTemplates.Count - 1)
            _currentSkinNumber = 0;
        else
            _currentSkinNumber++;

        if (_currentSkinNumber != _previousSkinNumber)
            _previousSkinNumber = _currentSkinNumber;

        ChangeSkinFase(_skinTemplates[_currentSkinNumber]);
    }

    public void PreviousSkinFase()
    {
        RemoveSkin(_skinTemplates[_currentSkinNumber]);

        if (_currentSkinNumber == 0)
            _currentSkinNumber = _skinTemplates.Count - 1;
        else
            _currentSkinNumber--;

        if(_currentSkinNumber != _previousSkinNumber)
           _previousSkinNumber = _currentSkinNumber;


        ChangeSkinFase(_skinTemplates[_currentSkinNumber]);
    }

    private void ChangeSkinFase(Skin skin)
    {
        SetSkin(skin);
    }

    private void SetSkin(Skin skin)
    {
        Instantiate(skin, transform);
    }

    private void RemoveSkin(Skin skin)
    {
        if(skin == null)
        {
            Destroy(skin);
        }
    }
}
