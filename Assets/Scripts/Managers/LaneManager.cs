using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class LaneManager : MonoBehaviour
{
    //Instance creation for 
    //public static LaneManager instance;

    Vector3[] _gameLanes;
    Vector3[] _laneSpawnPositions;

    protected int _laneAmount = 3;

    protected static Vector3 _startPositionModifier = new Vector3(0, 0, 15);

    protected static Vector3 _leftLane = new Vector3(-2,0.5f,0);
    protected static Vector3 _leftLaneStartPosition = _leftLane + _startPositionModifier;

    protected static Vector3 _middleLane = new Vector3(0,0.5f,0);
    protected static Vector3 _middleLaneStartPosition = _middleLane + _startPositionModifier;

    protected static Vector3 _rightLane = new Vector3(2,0.5f,0);
    protected static Vector3 _rightLaneStartPosition = _rightLane + _startPositionModifier;

    public void SetupGameLanes()
    {
        _gameLanes = new Vector3[_laneAmount];
        _gameLanes[0] = _leftLane;
        _gameLanes[1] = _middleLane;
        _gameLanes[2] = _rightLane;


        _laneSpawnPositions = new Vector3[_laneAmount];
        _laneSpawnPositions[0] = _leftLaneStartPosition;
        _laneSpawnPositions[1] = _middleLaneStartPosition;
        _laneSpawnPositions[2] = _rightLaneStartPosition;
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
    //The parameter int laneNumber determines which lane the obstacle gets set to.
    //1 is the leftmost lane, 2 is the middle lane, 3 is the rightmost lane.
    public void SetObstacleLane(int laneNumber)
    {
        switch (laneNumber)
        {
            case 1:
                transform.position = _laneSpawnPositions[0];
                break;

            case 2:
                transform.position = _laneSpawnPositions[1];
                break;

            case 3:
                transform.position = _laneSpawnPositions[2];
                break;

            //sets the middle lane to be the default
            default:
                transform.position = _laneSpawnPositions[1];
                return;

        }
    }

    void SetPlayerLane(int laneNumber)
    {

    }
}
