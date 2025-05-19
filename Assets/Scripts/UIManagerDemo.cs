using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;

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

    private PlayerLivesBehavior _playerLives;

    private ScoreManager _scoreManagerScript;

    private void Start()
    {
        if (_player.TryGetComponent(out PlayerLivesBehavior lives))
            _playerLives = lives;

        if (_scoreManager.TryGetComponent(out ScoreManager score))
            _scoreManagerScript = score;
    }

    private void Update()
    {
        if (_scoreText && _scoreManagerScript)
            _scoreText.text = _scoreManagerScript.Score.ToString("Score: 000000");

        if (_playerLivesText && _playerLives)
            _playerLivesText.text = _playerLives.Lives.ToString("Lives: 0");
    }
}
