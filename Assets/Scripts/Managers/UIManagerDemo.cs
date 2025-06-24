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

        if (_quitButton.TryGetComponent(out Button button))
            button.onClick.AddListener(QuitGame);
    }

    private void Update()
    {
        if (_scoreText && _scoreManagerScript)
            _scoreText.text = _scoreManagerScript.Score.ToString("Score: 00000000");

        if (_playerLivesText && _playerLives)
            _playerLivesText.text = _playerLives.Lives.ToString("Lives: 0");
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

        _finalScoreText.alpha = 1;
        _finalScoreText.text = _scoreManagerScript.Score.ToString("Your Final Score is: \n 00000000");

        _scoreText.alpha = 0;
        _playerLivesText.alpha = 0;
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
