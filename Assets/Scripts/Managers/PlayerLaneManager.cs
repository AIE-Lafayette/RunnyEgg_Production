using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaneManager : MonoBehaviour
{
    public LaneManager LanesManager;

    [SerializeField]
    private Transform _playerTransform;

    [SerializeField]
    private float _playerMovementSpeed;

    private int _playerLaneIndex = 1;

    public int GetPlayerLaneIndex()
    {
        return _playerLaneIndex;
    }

    // Start is called before the first frame update
    private void Start()
    {
        LanesManager.SetupGameLanes();
        _playerTransform.position = LanesManager.GameLanes[GetPlayerLaneIndex()];
    }

    private void Update()
    {
        // move the player towards their current lane should that not be where they are
        if (_playerTransform.position.x != LanesManager.GameLanes[_playerLaneIndex].x)
        {
            Vector3 newPosition = _playerTransform.position;
            newPosition.x = Mathf.Lerp(_playerTransform.position.x, LanesManager.GameLanes[_playerLaneIndex].x, _playerMovementSpeed * Time.deltaTime);
            _playerTransform.position = newPosition;
        }
    }

    public void MovePlayerLeft()
    {
        if (_playerLaneIndex <= 0)
            return;

        _playerLaneIndex--;
    }

    public void MovePlayerRight()
    {
        if (_playerLaneIndex >= LanesManager.GameLanes.Length - 1)
            return;

        _playerLaneIndex++;
    }
}
