using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class LaneManager : MonoBehaviour
{
    Vector3[] _gameLanes;
    Vector3[] _laneSpawnPositions;

    private int _laneAmount = 3;

    private static Vector3 _startPositionModifier = new Vector3(0, 0, 25);

    private static Vector3 _leftLane = new Vector3(-2, 0.5f, 0);
    private static Vector3 _leftLaneStartPosition = _leftLane + _startPositionModifier;

    private static Vector3 _middleLane = new Vector3(0, 0.5f, 0);
    private static Vector3 _middleLaneStartPosition = _middleLane + _startPositionModifier;

    private static Vector3 _rightLane = new Vector3(2, 0.5f, 0);
    private static Vector3 _rightLaneStartPosition = _rightLane + _startPositionModifier;

    private static Vector3 _destroyZone = new Vector3(0, 0, -5);


    public int GetLaneAmount()
    {
        return _laneAmount;
    }

    public Vector3 GetLeftLane()
    {
        return _leftLane;
    }

    public Vector3 GetLeftLaneStartPos()
    {
        return _leftLaneStartPosition;
    }

    public Vector3 GetMiddleLane()
    {
        return _middleLane;
    }

    public Vector3 GetMiddleLaneStartPos()
    {
        return _middleLaneStartPosition;
    }

    public Vector3 GetRightLane()
    {
        return _rightLane;
    }

    public Vector3 GetRightLaneStartPos()
    {
        return _rightLaneStartPosition;
    }

    public float GetDestroyZone()
    {
        return _destroyZone.z;
    }
        
    //Establishes the positions and indexes of the three lanes in the game
    public void SetupGameLanes()
    {
        _gameLanes = new Vector3[GetLaneAmount()];
        _gameLanes[0] = GetLeftLane();
        _gameLanes[1] = GetMiddleLane();
        _gameLanes[2] = GetRightLane();


        _laneSpawnPositions = new Vector3[GetLaneAmount()];
        _laneSpawnPositions[0] = GetLeftLaneStartPos();
        _laneSpawnPositions[1] = GetMiddleLaneStartPos();
        _laneSpawnPositions[2] = GetRightLaneStartPos();
    }

    public Vector3 GetRandomLane()
    {
        SetupGameLanes();
        int laneIndex = UnityEngine.Random.Range(0, GetLaneAmount());
        Vector3 randomLanePosition = new Vector3(_laneSpawnPositions[laneIndex].x, _laneSpawnPositions[laneIndex].y, _laneSpawnPositions[laneIndex].z);

        return randomLanePosition;
    }

    int GetPlayerLane()
    {
        return 0;
    }

    Vector3 GetObstacleLane()
    {
        if (transform.position.x == _gameLanes[0].x)
        {
            return _gameLanes[0];
        }
        else if (transform.position.x == _gameLanes[1].x)
        {
            return _gameLanes[1];
        }
        else if (transform.position.x == _gameLanes[2].x)
        {
            return _gameLanes[2];
        }
        else { return new Vector3(); }
    }

    //Sets an obstacle's lane to one of the three positions.
    public Vector3 SetObstacleLane()
    {
        Vector3 determinedLane = new Vector3();

        if (gameObject.CompareTag("MiddleFillingObstacle"))
        {
            determinedLane = GetMiddleLaneStartPos();
        }
        else if (gameObject.CompareTag("Obstacle"))
        {
            determinedLane = GetRandomLane();
        }

        return determinedLane;
    }

    void SetPlayerLane(int laneNumber)
    {

    }
}
