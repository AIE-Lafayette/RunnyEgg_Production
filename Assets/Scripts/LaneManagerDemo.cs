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

    // this stuff down here doesnt work at all and i really don't feel like fixing it
    // especially since this is  a demo script of how it *could* work. i mean,, it sets the values ??  that's fine enough i guess
    public void MovePlayerLeft()
    {
        if (_playerLaneIndex <= 0)
            return;

        _playerLaneIndex--;
        _playerTransform.position = _lanePositions[_playerLaneIndex];
        Debug.Log(_playerLaneIndex);
        Debug.Log(_playerTransform.position);
    }

    public void MovePlayerRight()
    {
        if (_playerLaneIndex >= _lanePositions.Length - 1)
            return;

        _playerLaneIndex++;
        _playerTransform.position = _lanePositions[_playerLaneIndex];
        Debug.Log(_playerLaneIndex);
        Debug.Log(_playerTransform.position);
    }
}
