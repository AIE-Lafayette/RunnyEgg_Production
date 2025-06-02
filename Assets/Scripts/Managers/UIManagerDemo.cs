using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerDemo : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;

    [SerializeField]
    private TextMeshProUGUI _playerLivesText;

    [SerializeField]
    private GameObject _scoreManager;

    [SerializeField]
    private TextMeshProUGUI _scoreText;

    [SerializeField]
    private GameObject _titleScreenManager;

    [SerializeField]
    private GameObject _startButton;

    [SerializeField]
    private GameObject _quitButton;

    private PlayerLivesBehavior _playerLives;

    private ScoreManager _scoreManagerScript;

    private TitleScreenManager _titleScreenManagerScript;

    private void Start()
    {
        if (_player.TryGetComponent(out PlayerLivesBehavior lives))
            _playerLives = lives;

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
        _startButton.SetActive(false);
        _quitButton.SetActive(false);

        _scoreText.alpha = 1;
        _playerLivesText.alpha = 1;
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
