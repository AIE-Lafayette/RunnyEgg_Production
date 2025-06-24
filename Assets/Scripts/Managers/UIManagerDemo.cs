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
    private GameObject _playerLivesText;

    [SerializeField]
    private GameObject[] _playerLifeIcons;

    [SerializeField]
    private TextMeshProUGUI _finalScoreText;

    [SerializeField]
    private Sprite _lostLifeImage;


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

        // setup all of the different objects, disabling some and adding listeners to others
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
            _playerLivesText.SetActive(false);

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

        for (int i = 0; i < _playerLifeIcons.Length; i++)
        {
            _playerLifeIcons[i].SetActive(false);
        }

        if (_quitButton.TryGetComponent(out Button button))
            button.onClick.AddListener(QuitGame);

        _playerLives.OnLifeLost.AddListener(UpdateLivesIcons);
    }

    private void Update()
    {
        // set score text
        if (_scoreText && _scoreManagerScript)
            _scoreText.text = _scoreManagerScript.Score.ToString("00000000");

        // if the game is over, fade in the game over screen
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

    private void UpdateLivesIcons()
    {
        // change the image shown on each life icon to be the image for a lost life if that life is lost
        for (int i = 0; i < _playerLifeIcons.Length; i++)
        {
            if (i >= _playerLives.Lives)
            {
                if (_playerLifeIcons[i].TryGetComponent(out Image img))
                    img.overrideSprite = _lostLifeImage;
            }
        }
    }

    private void SwapToGameplayUI()
    {
        // disable the title screen ui and enable the gameplay ui
        _titleImage.SetActive(false);
        _startButton.SetActive(false);
        _creditsButton.SetActive(false);
        _quitButton.SetActive(false);

        _scoreText.alpha = 1;
        _playerLivesText.SetActive(true);

        for (int i = 0; i < _playerLifeIcons.Length; i++)
        {
            _playerLifeIcons[i].SetActive(true);
        }
    }

    private void SwapToGameOverUI()
    {
        // disable the gameplay ui and enable the game over ui
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
        _playerLivesText.SetActive(false);

        _gameOverBorder.SetActive(true);
        _gameOverImage.SetActive(true);

        for (int i = 0; i < _playerLifeIcons.Length; i++)
        {
            _playerLifeIcons[i].SetActive(false);
        }

        _isGameOver = true;
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
