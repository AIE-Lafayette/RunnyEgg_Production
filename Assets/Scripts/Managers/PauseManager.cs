using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
    [SerializeField]
    private InputActionReference _pauseInput;

    [SerializeField]
    private GameObject _player;

    [SerializeField]
    private ScoreManager _scoreManager;

    [SerializeField]
    private GameObject _uiManager;

    private Rigidbody _playerRigidbody;

    private PlayerController _playerController;

    private PlayerLivesBehavior _playerLivesBehavior;

    private Vector3 _playerVelocity;

    public UnityEvent OnPause;

    public UnityEvent OnUnPause;

    private bool _isGamePaused;

    private void Start()
    {
        if (_player.TryGetComponent(out Rigidbody rigidbody))
            _playerRigidbody = rigidbody;

        if (_player.TryGetComponent(out PlayerController controller))
            _playerController = controller;

        if (_player.TryGetComponent(out PlayerLivesBehavior lives))
            _playerLivesBehavior = lives;
    }

    private void Update()
    {
        if (_pauseInput.action.WasPressedThisFrame())
            PauseGame();
    }

    private void PauseGame()
    {
        if (_isGamePaused)
        {
            UnPauseGame();
            return;
        }

        OnPause.Invoke();

        _scoreManager.enabled = false;
        _playerController.enabled = false;
        _playerLivesBehavior.enabled = false;

        _playerVelocity = _playerRigidbody.velocity;
        _playerRigidbody.isKinematic = true;

        _isGamePaused = true;
    }

    private void UnPauseGame()
    {
        OnUnPause.Invoke();

        _scoreManager.enabled = true;
        _playerController.enabled = true;
        _playerLivesBehavior.enabled = true;

        _playerRigidbody.isKinematic = false;
        _playerRigidbody.AddForce(_playerVelocity, ForceMode.VelocityChange);


        _isGamePaused = false;
    }
}
