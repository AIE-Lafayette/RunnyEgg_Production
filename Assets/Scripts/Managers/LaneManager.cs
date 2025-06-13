using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class LaneManager : MonoBehaviour
{
    public Vector3[] _gameLanes;
    public Vector3[] _laneSpawnPositions;

    private int _laneAmount = 3;

    private static Vector3 _startPositionModifier = new Vector3(0, 0, 35);

    private static Vector3 _leftLane = new Vector3(-3, 0, 0);
    private static Vector3 _leftLaneStartPosition = _leftLane + _startPositionModifier;

    private static Vector3 _middleLane = new Vector3(0, 0, 0);
    private static Vector3 _middleLaneStartPosition = _middleLane + _startPositionModifier;

    private static Vector3 _rightLane = new Vector3(3, 0, 0);
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

    public Vector3 GetMiddleOrLeftLaneSpawns()
    {
        Vector3 chosenLane = new Vector3();

        int laneDeterminer = UnityEngine.Random.Range(1, 3);

        switch (laneDeterminer)
        {
            case 1:
                chosenLane = GetLeftLaneStartPos();
                break;
            case 2:
                chosenLane = GetMiddleLaneStartPos();
                break;
            default:
                chosenLane = GetMiddleLaneStartPos();
                break;
        }

        return chosenLane;
    }

    public Vector3 GetMiddleOrRightLaneSpawns()
    {
        Vector3 chosenLane = new Vector3();

        int laneDeterminer = UnityEngine.Random.Range(1, 3);

        switch (laneDeterminer)
        {
            case 1:
                chosenLane = GetRightLaneStartPos();
                break;
            case 2:
                chosenLane = GetMiddleLaneStartPos();
                break;
            default:
                chosenLane = GetMiddleLaneStartPos();
                break;
        }

        return chosenLane;
    }

    public Vector3 GetLeftOrRightLaneSpawns()
    {
        Vector3 chosenLane = new Vector3();

        int laneDeterminer = UnityEngine.Random.Range(1, 3);

        switch (laneDeterminer)
        {
            case 1:
                chosenLane = GetLeftLaneStartPos();
                break;
            case 2:
                chosenLane = GetRightLaneStartPos();
                break;
            default:
                chosenLane = GetRightLaneStartPos();
                break;
        }

        return chosenLane;
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

    public void Start()
    {
        SetupGameLanes();
    }

    public Vector3 GetRandomSpawnLane()
    {
        int laneIndex = UnityEngine.Random.Range(0, GetLaneAmount());
        Vector3 randomLanePosition = new Vector3(_laneSpawnPositions[laneIndex].x, _laneSpawnPositions[laneIndex].y, _laneSpawnPositions[laneIndex].z);

        return randomLanePosition;
    }

    //Returns a float value that can be used as an obstacle's lane position
    //Passing 1 as a parameter returns the left lane, 2 the middle lane, 3 the right lane
    //The middle lane is returned on default
    public float GetObstacleLane(int laneNumber)
    {
        float lanePosition;

        switch (laneNumber)
        {
            case 1:
                lanePosition = _gameLanes[0].x;
                break;
            case 2:
                lanePosition = _gameLanes[1].x;
                break;
            case 3:
                lanePosition = _gameLanes[2].x;
                break;
            default:
                lanePosition = _gameLanes[1].x;
                break;
        }

        return lanePosition;
    }


}
