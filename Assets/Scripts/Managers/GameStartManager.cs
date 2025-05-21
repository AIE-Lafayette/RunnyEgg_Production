using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private CameraTransform _gameplayCameraTransform;

    [SerializeField]
    [Tooltip("The time it will take to move the camera at the start of the game <i>in frames.</i>")]
    private uint _cameraMoveTime;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            StartGame();
    }

    public void StartGame()
    {
        // preddy quickly but not instantly move the camera to the gameplay camera position & rotation
        // coroutine would work really !
        StartCoroutine("MoveCamera");
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

        // move & rotate the camera
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
