using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameStartManager : MonoBehaviour
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
    [Tooltip("The time it will take to move the camera at the start of the game <i>in frames.</i> This objectively sucks, but I don't know how to make it work with Time.deltaTime. ):")]
    private uint _cameraMoveTime;

    private bool _gameStarted = false;

    public UnityEvent OnGameStart;

    private void Update()
    {
        // temporary dev game start button
        if (Input.GetKeyDown(KeyCode.F))
            StartGame();
    }

    public void StartGame()
    {
        if (_gameStarted)
            return;

        // preddy quickly but not instantly move the camera to the gameplay camera position & rotation
        StartCoroutine("MoveCamera");

        OnGameStart.Invoke();

        // make sure this function never happens again
        _gameStarted = true;
    }

    private IEnumerator MoveCamera()
    {
        // do some quick math to figure out how much the camera needs to move & rotate per frame
        float cameraMovementPerFrameX = (_gameplayCameraTransform.position.x - _gameCamera.transform.position.x) / _cameraMoveTime;
        float cameraMovementPerFrameY = (_gameplayCameraTransform.position.y - _gameCamera.transform.position.y) / _cameraMoveTime;
        float cameraMovementPerFrameZ = (_gameplayCameraTransform.position.z - _gameCamera.transform.position.z) / _cameraMoveTime;

        Vector3 cameraMovementPerFrameVector = new Vector3(cameraMovementPerFrameX, cameraMovementPerFrameY, cameraMovementPerFrameZ);

        
        float cameraRotationPerFrameX = (_gameplayCameraTransform.rotation.x - _gameCamera.transform.rotation.eulerAngles.x) / _cameraMoveTime;
        float cameraRotationPerFrameY = (_gameplayCameraTransform.rotation.y - _gameCamera.transform.rotation.eulerAngles.y) / _cameraMoveTime;
        float cameraRotationPerFrameZ = (_gameplayCameraTransform.rotation.z - _gameCamera.transform.rotation.eulerAngles.z) / _cameraMoveTime;

        Vector3 cameraRotationPerFrameVector = new Vector3(cameraRotationPerFrameX, cameraRotationPerFrameY, cameraRotationPerFrameZ);

        // move & rotate the camera to the position
        for (int i = 0; i < _cameraMoveTime; i++)
        {
            Vector3 newCameraPosition = _gameCamera.transform.position;
            Vector3 newCameraRotation = _gameCamera.transform.rotation.eulerAngles;

            newCameraPosition += cameraMovementPerFrameVector;
            newCameraRotation += cameraRotationPerFrameVector;

            _gameCamera.transform.position = newCameraPosition;
            _gameCamera.transform.rotation = Quaternion.Euler(newCameraRotation);

            yield return null;
        }

        _gameCamera.transform.position = _gameplayCameraTransform.position;
        _gameCamera.transform.rotation = Quaternion.Euler(_gameplayCameraTransform.rotation);

        yield break;
    }
}
