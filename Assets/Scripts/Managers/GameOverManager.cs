using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameOverManager : MonoBehaviour
{
    [SerializeField]
    private ObstacleSpawnManager _obstacleSpawnManager;

    [SerializeField]
    private CollectibleSpawnManager _collectibleSpawnManager;

    [SerializeField]
    private ScoreManager _scoreManager;

    [SerializeField]
    private UIManagerDemo _uiManager;

    [SerializeField]
    private PlayerLivesBehavior _playerLives;

    private void Start()
    {
        if (_playerLives)
            _playerLives.OnAllLivesLost.AddListener(GameOver);
    }

    private void GameOver()
    {
        _obstacleSpawnManager.enabled = false;
        _collectibleSpawnManager.enabled = false;
        _scoreManager.enabled = false;
    }
}
