using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerDemo : MonoBehaviour
{
    [SerializeField]
    private GameObject _scoreManager;


    [SerializeField]
    private GameObject _titleScreenManager;

    [SerializeField]
    private GameObject _player;


    [Space(10)]


    [SerializeField]
    private TextMeshProUGUI _scoreText;

    [SerializeField]
    private TextMeshProUGUI _playerLivesText;

    [SerializeField]
    private TextMeshProUGUI _finalScoreText;


    [Space(10)]


    [SerializeField]
    private GameObject _titleImage;

    [SerializeField]
    private GameObject _gameOverImage;

    [SerializeField]
    private GameObject _gameOverBorder;

    [SerializeField]
    private GameObject _startButton;

    [SerializeField]
    private GameObject _creditsButton;

    [SerializeField]
    private GameObject _quitButton;

    [SerializeField]
    private GameObject _restartButton;

    private PlayerLivesBehavior _playerLives;

    private ScoreManager _scoreManagerScript;

    private TitleScreenManager _titleScreenManagerScript;

    public GameObject RestartButton { get => _restartButton; }

    private bool _isGameOver;

    private float _gameOverAlpha;

    private void Start()
    {

        if (_player.TryGetComponent(out PlayerLivesBehavior lives))
        {
            _playerLives = lives;
            lives.OnAllLivesLost.AddListener(SwapToGameOverUI);
        }

        if (_scoreManager.TryGetComponent(out ScoreManager score))
            _scoreManagerScript = score;

        if (_titleScreenManager.TryGetComponent(out TitleScreenManager titleScreen))
        {
            _titleScreenManagerScript = titleScreen;
            _titleScreenManagerScript.OnGameStart.AddListener(SwapToGameplayUI);
        }

        if (_playerLivesText)
            _playerLivesText.alpha = 0;

        if (_scoreText)
            _scoreText.alpha = 0;

        if (_finalScoreText)
            _finalScoreText.alpha = 0;


        _gameOverAlpha = 0;

        if (_gameOverImage.TryGetComponent(out Image g))
        {
            Color newValue = g.color;
            newValue.a = _gameOverAlpha;
            g.color = newValue;
        }

        if (_gameOverBorder.TryGetComponent(out Image gb))
        {
            Color newValue = gb.color;
            newValue.a = _gameOverAlpha;
            gb.color = newValue;
        }

        if (_quitButton.TryGetComponent(out Button button))
            button.onClick.AddListener(QuitGame);
    }

    private void Update()
    {
        if (_scoreText && _scoreManagerScript)
            _scoreText.text = _scoreManagerScript.Score.ToString("Score: 00000000");

        if (_playerLivesText && _playerLives)
            _playerLivesText.text = _playerLives.Lives.ToString("Lives: 0");

        if (_isGameOver && _gameOverAlpha < 1)
        {
            _gameOverAlpha = Mathf.Lerp(_gameOverAlpha, 1.0f, Time.deltaTime);

            if (_gameOverImage.TryGetComponent(out Image g))
            {
                Color newValue = g.color;
                newValue.a = _gameOverAlpha;
                g.color = newValue;
            }

            if (_gameOverBorder.TryGetComponent(out Image gb))
            {
                Color newValue = gb.color;
                newValue.a = _gameOverAlpha * 2;
                gb.color = newValue;
            }
        }
    }

    private void SwapToGameplayUI()
    {
        _titleImage.SetActive(false);
        _startButton.SetActive(false);
        _creditsButton.SetActive(false);
        _quitButton.SetActive(false);

        _scoreText.alpha = 1;
        _playerLivesText.alpha = 1;
    }

    private void SwapToGameOverUI()
    {
        _restartButton.SetActive(true);
        _quitButton.SetActive(true);

        if (_quitButton.TryGetComponent(out RectTransform rect))
        {
            Vector3 quitPosition = rect.position;
            quitPosition.x += 200;
            quitPosition.y -= 100;
            rect.position = quitPosition;
        }

        _finalScoreText.alpha = 1;
        _finalScoreText.text = _scoreManagerScript.Score.ToString("Your Final Score is: \n 00000000");

        _scoreText.alpha = 0;
        _playerLivesText.alpha = 0;

        _gameOverBorder.SetActive(true);
        _gameOverImage.SetActive(true);

        _isGameOver = true;
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
