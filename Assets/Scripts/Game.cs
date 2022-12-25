using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private GameScreen _gameScreen;
    [SerializeField] private PauseMenuScreen _pauseMenuScreen;
    [SerializeField] private ShopScreen _shopScreen;
    [SerializeField] private SkinChangeScreen _skinChangeScreen;

    private void OnEnable()
    {
        _startScreen.PlayButtonClick += OnStartGame;

        _player.GameOver += OnGameOver;

        _gameOverScreen.RestartButtonClick += OnRestartGame;
        _gameOverScreen.StartMenuButtonClick += OnStartMenu;

        _gameScreen.PauseButtonClick += OnPauseMenuScreen;

        _pauseMenuScreen.ExitButtonClick += OnExitPauseMenuScreen;
        _pauseMenuScreen.StartMenuButtonClick += OnStartMenu;
        _pauseMenuScreen.RestartButtonClick += OnRestartGame;

        _startScreen.ShopButtonClick += OnShopScreen;
        _startScreen.SkinChangeButtonClick += OnSkinChangeScreen;

        _shopScreen.ExitButtonClick += OnExitShopScreen;

        _skinChangeScreen.ExitButtonClick += OnExitSkinChangeScreen;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClick -= OnStartGame;

        _player.GameOver -= OnGameOver;

        _gameOverScreen.RestartButtonClick -= OnRestartGame;
        _gameOverScreen.StartMenuButtonClick -= OnStartMenu;

        _gameScreen.PauseButtonClick -= OnPauseMenuScreen;

        _pauseMenuScreen.ExitButtonClick -= OnExitPauseMenuScreen;
        _pauseMenuScreen.StartMenuButtonClick -= OnStartMenu;
        _pauseMenuScreen.RestartButtonClick -= OnRestartGame;

        _startScreen.ShopButtonClick -= OnShopScreen;
        _startScreen.SkinChangeButtonClick -= OnSkinChangeScreen;

        _shopScreen.ExitButtonClick -= OnExitShopScreen;

        _skinChangeScreen.ExitButtonClick -= OnExitSkinChangeScreen;
    }

    private void Start()
    {
        _startScreen.Open();
        _gameOverScreen.Close();
        _gameScreen.Close();
        _pauseMenuScreen.Close();
        _shopScreen.Close();
        _skinChangeScreen.Close();
    }

    private void OnStartGame()
    {
        _startScreen.Close();
        StartGame();
    }

    private void OnRestartGame()
    {
        _gameOverScreen.Close();
        _pauseMenuScreen.Close();
        StartGame();
    }

    private void OnStartMenu()
    {
        _gameOverScreen.Close();
        _gameScreen.Close();
        _pauseMenuScreen.Close();
        _startScreen.Open();
    }

    private void OnPauseMenuScreen()
    {
        _playerMover.TurnOffControl();
        _gameScreen.Close();
        _pauseMenuScreen.Open();
    }

    private void OnShopScreen()
    {
        _startScreen.Close();
        _shopScreen.Open();
    }

    private void OnSkinChangeScreen()
    {
        _startScreen.Close();
        _skinChangeScreen.Open();
    }

    private void OnExitShopScreen()
    {
        _shopScreen.Close();
        _startScreen.Open();
    }

    private void OnExitSkinChangeScreen()
    {
        _skinChangeScreen.Close();
        _startScreen.Open();
    }

    private void OnExitPauseMenuScreen()
    {
        _pauseMenuScreen.Close();
        _gameScreen.Open();
        _playerMover.TurnOnControl();
    }

    private void StartGame()
    {
        _player.Restart();
        _gameScreen.Open();
    }

    public void OnGameOver()
    {
        _playerMover.TurnOffCollider();
        _gameOverScreen.Open();
    }
}
