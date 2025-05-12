using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class LaneManager : MonoBehaviour
{
    public static LaneManager instance;

    Vector3[] _gameLanes;

    int _laneAmount = 6;

    Vector3 _startPositionModifier = new Vector3(0, 0, 15);

    public void SetupGameLanes()
    {
        Vector3 _leftLane = new Vector3(-2,0.5f,0);
        Vector3 _leftLaneStartPosition = _leftLane + _startPositionModifier;

        Vector3 _middleLane = new Vector3(0,0.5f,0);
        Vector3 _middleLaneStartPosition = _middleLane + _startPositionModifier;

        Vector3 _rightLane = new Vector3(2,0.5f,0);
        Vector3 _rightLaneStartPosition = _rightLane + _startPositionModifier;


        _gameLanes = new Vector3[_laneAmount];
        _gameLanes[0] = _leftLane;
        _gameLanes[1] = _leftLaneStartPosition;
        _gameLanes[2] = _middleLane;
        _gameLanes[3] = _middleLaneStartPosition;
        _gameLanes[4] = _rightLane;
        _gameLanes[5] = _rightLaneStartPosition;
    }

    int GetPlayerLane()
    {
        return 0;
    }

    int GetObstacleLane()
    {
        if (transform.position.x == _gameLanes[0].x)
        {
            return 1;
        }
        else if (transform.position.x == _gameLanes[1].x)
        {
            return 2;
        }
        else if (transform.position.x == _gameLanes[2].x)
        {
            return 3;
        }
        else { return 0; }
    }

    public void SetObstacleLane(int laneNumber)
    {
        switch (laneNumber)
        {
            case 1:
                transform.position = _gameLanes[1];
                break;

            case 2:
                transform.position = _gameLanes[3];
                break;

            case 3:
                transform.position = _gameLanes[5];
                break;

            //sets the middle lane to be the default
            default:
                transform.position = _gameLanes[3];
                return;

        }
    }

    void SetPlayerLane(int laneNumber)
    {

    }
}
