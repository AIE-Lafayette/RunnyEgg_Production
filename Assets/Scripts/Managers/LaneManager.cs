using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class LaneManager : MonoBehaviour
{
    public Vector3[] GameLanes;
    public Vector3[] LaneSpawnPositions;

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

    public float GetLeftLanePos()
    {
        return _leftLane.x;
    }

    public Vector3 GetLeftLane()
    {
        return _leftLane;
    }

    public Vector3 GetLeftLaneStartPos()
    {
        return _leftLaneStartPosition;
    }

    public float GetMiddleLanePos()
    {
        return _middleLane.x;
    }

    public Vector3 GetMiddleLane()
    {
        return _middleLane;
    }

    public Vector3 GetMiddleLaneStartPos()
    {
        return _middleLaneStartPosition;
    }

    public float GetRightLanePos()
    {
        return _rightLane.x;
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
        GameLanes = new Vector3[GetLaneAmount()];
        GameLanes[0] = GetLeftLane();
        GameLanes[1] = GetMiddleLane();
        GameLanes[2] = GetRightLane();


        LaneSpawnPositions = new Vector3[GetLaneAmount()];
        LaneSpawnPositions[0] = GetLeftLaneStartPos();
        LaneSpawnPositions[1] = GetMiddleLaneStartPos();
        LaneSpawnPositions[2] = GetRightLaneStartPos();
    }

    public void Start()
    {
        SetupGameLanes();
    }

    public Vector3 GetRandomSpawnLane()
    {
        int laneIndex = UnityEngine.Random.Range(0, GetLaneAmount());
        Vector3 randomLanePosition = new Vector3(LaneSpawnPositions[laneIndex].x, LaneSpawnPositions[laneIndex].y, LaneSpawnPositions[laneIndex].z);

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
                lanePosition = GameLanes[0].x;
                break;
            case 2:
                lanePosition = GameLanes[1].x;
                break;
            case 3:
                lanePosition = GameLanes[2].x;
                break;
            default:
                lanePosition = GameLanes[1].x;
                break;
        }

        return lanePosition;
    }


}
