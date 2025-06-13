using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    private GameObject _player;

    private PlayerController _playerController;

    private void Start()
    {
        if (_player.TryGetComponent(out PlayerLivesBehavior lives))
            lives.OnAllLivesLost.AddListener(GameOver);

        if (_player.TryGetComponent(out PlayerController controller))
            _playerController = controller;

        if (_uiManager && _uiManager.RestartButton && _uiManager.RestartButton.TryGetComponent(out Button button))
            button.onClick.AddListener(Restart);
            
    }

    private void GameOver()
    {
        // stop obstacles from spawning
        _obstacleSpawnManager.CancelInvoke();
        _collectibleSpawnManager.CancelInvoke();

        // stop score manager and player controller from updating
        _scoreManager.enabled = false;
        _playerController.enabled = false;
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
