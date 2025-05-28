using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaneManager : MonoBehaviour
{
    public LaneManager _laneManager;

    [SerializeField]
    private Transform _playerTransform;

    private int _playerLaneIndex = 1;

    public int GetPlayerLaneIndex()
    {
        return _playerLaneIndex;
    }

    // Start is called before the first frame update
    void Start()
    {
        _laneManager.SetupGameLanes();
        _playerTransform.position = _laneManager._gameLanes[GetPlayerLaneIndex()];
    }

    public void MovePlayerLeft()
    {
        if (_playerLaneIndex <= 0)
            return;

        _playerLaneIndex--;
        Vector3 newPosition = _playerTransform.position;
        newPosition.x = _laneManager._gameLanes[_playerLaneIndex].x;
        _playerTransform.position = newPosition;
    }

    public void MovePlayerRight()
    {
        if (_playerLaneIndex >= _laneManager._gameLanes.Length - 1)
            return;

        _playerLaneIndex++;
        Vector3 newPosition = _playerTransform.position;
        newPosition.x = _laneManager._gameLanes[_playerLaneIndex].x;
        _playerTransform.position = newPosition;
    }
}
