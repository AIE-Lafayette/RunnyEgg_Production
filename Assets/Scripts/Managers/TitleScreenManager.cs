using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Events;

public class TitleScreenManager : MonoBehaviour
{
    [System.Serializable]
    public struct CameraTransform
    {
        public Vector3 position;
        public Vector3 rotation;
        public CameraTransform(Vector3 position, Vector3 rotation)
        {
            this.position = position;
            this.rotation = rotation;
        }
    }

    [SerializeField]
    private Camera _gameCamera;

    [SerializeField]
    [Tooltip("The position and rotation the camera will move to when the game starts.")]
    private CameraTransform _gameplayCameraTransform;

    [SerializeField]
    private float _cameraMoveSpeed = 10.0f;

    [SerializeField]
    private float _cameraRotationSpeed = 30.0f;

    [SerializeField]
    private ScoreManager _scoreManager;

    [SerializeField]
    private PauseManager _pauseManager;

    [SerializeField]
    private ObstacleSpawnManager _obstacleManager;

    [SerializeField]
    private CollectibleSpawnManager _collectibleManager;

    [SerializeField]
    private GameObject _player;

    private PlayerController _playerController;

    private bool _isGameStarted = false;

    public UnityEvent OnGameStart;

    public bool IsGameStarted { get => _isGameStarted; }

    private void Start()
    {
        if (_player.TryGetComponent(out PlayerController controller))
        {
            _playerController = controller;
            _playerController.enabled = false;
        }
    }

    public void StartGame()
    {
        // dont start the game if it's already started
        if (_isGameStarted)
            return;

        // preddy quickly but not instantly move the camera to the gameplay camera position & rotation
        StartCoroutine("MoveCamera");

        _scoreManager.enabled = true;
        _playerController.enabled = true;
        _pauseManager.enabled = true;
        _obstacleManager.enabled = true;
        _collectibleManager.enabled = true;

        OnGameStart.Invoke();

        _isGameStarted = true;
    }

    private IEnumerator MoveCamera()
    {
        // move & rotate the camera at the given speeds
        while (_gameCamera.transform.position != _gameplayCameraTransform.position || _gameCamera.transform.rotation.eulerAngles != _gameplayCameraTransform.rotation)
        {
            Vector3 newCameraPosition = _gameCamera.transform.position;
            Vector3 newCameraRotation = _gameCamera.transform.rotation.eulerAngles;

            newCameraPosition.x = Mathf.MoveTowards(newCameraPosition.x, _gameplayCameraTransform.position.x, _cameraMoveSpeed * Time.deltaTime);
            newCameraPosition.y = Mathf.MoveTowards(newCameraPosition.y, _gameplayCameraTransform.position.y, _cameraMoveSpeed * Time.deltaTime);
            newCameraPosition.z = Mathf.MoveTowards(newCameraPosition.z, _gameplayCameraTransform.position.z, _cameraMoveSpeed * Time.deltaTime);

            newCameraRotation.x = Mathf.MoveTowardsAngle(newCameraRotation.x, _gameplayCameraTransform.rotation.x, _cameraRotationSpeed * Time.deltaTime);
            newCameraRotation.y = Mathf.MoveTowardsAngle(newCameraRotation.y, _gameplayCameraTransform.rotation.y, _cameraRotationSpeed * Time.deltaTime);
            newCameraRotation.z = Mathf.MoveTowardsAngle(newCameraRotation.z, _gameplayCameraTransform.rotation.z, _cameraRotationSpeed * Time.deltaTime);

            _gameCamera.transform.position = newCameraPosition;
            _gameCamera.transform.rotation = Quaternion.Euler(newCameraRotation);

            yield return null;
        }

        yield break;
    }
}
