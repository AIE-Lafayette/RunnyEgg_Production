using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneManagerDemo : MonoBehaviour
{
    [SerializeField]
    private Transform _playerTransform;

    [SerializeField]
    private Vector3[] _lanePositions;

    [SerializeField]
    private int _playerLaneIndex;

    private int _lastPlayerLaneIndex;

    public void Start()
    {
        _playerTransform.position = _lanePositions[_playerLaneIndex];
    }

    /// <summary>
    /// Gets the position of the lane in the given index.
    /// </summary>
    /// <param name="index">The index given.</param>
    /// <returns>The position of the lane in the given index, as a Vector3.</returns>
    public Vector3 GetLanePosition(int index)
    {
        if (index < _lanePositions.Length && index >= 0)
            return _lanePositions[index];
        else
            return new Vector3();
    }

    // this stuff down here       work at all and i really               fix   it
    //                            demo script                  work.          it sets the values            fine 
    public void MovePlayerLeft()
    {
        if (_playerLaneIndex <= 0)
            return;

        _playerLaneIndex--;
        Vector3 newPosition = _playerTransform.position;
        newPosition.x = _lanePositions[_playerLaneIndex].x;
        _playerTransform.position = newPosition;
    }

    public void MovePlayerRight()
    {
        if (_playerLaneIndex >= _lanePositions.Length - 1)
            return;

        _playerLaneIndex++;
        Vector3 newPosition = _playerTransform.position;
        newPosition.x = _lanePositions[_playerLaneIndex].x;
        _playerTransform.position = newPosition;
    }
}
