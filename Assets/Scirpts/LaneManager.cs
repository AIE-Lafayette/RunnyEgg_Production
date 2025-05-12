using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class LaneManager : MonoBehaviour
{
    public static LaneManager instance;

    Vector3[] _gameLanes;

    public void SetupGameLanes()
    {
        int _laneAmount = 3;

        Vector3 _leftLanePosition = Vector3.left * 2;
        Vector3 _middleLanePosition = Vector3.zero;
        Vector3 _rightLanePosition = Vector3.right * 2;

        _gameLanes = new Vector3[_laneAmount];
        _gameLanes[0] = _leftLanePosition;
        _gameLanes[1] = _middleLanePosition;
        _gameLanes[2] = _rightLanePosition;
    }

    int GetPlayerLane()
    {
        return 0;
    }

    int GetObstacleLane()
    {
        if (transform.position == _gameLanes[0])
        {
            return 1;
        }
        else if (transform.position == _gameLanes[1])
        {
            return 2;
        }
        else if (transform.position == _gameLanes[2])
        {
            return 3;
        }
        else { return 0; }
    }

    void SetObstacleLane(int laneNumber)
    {
        switch (laneNumber)
        {
            case 1:
                transform.position = _gameLanes[0];
                break;

            case 2:
                transform.position = _gameLanes[1];
                break;

            case 3:
                transform.position = _gameLanes[2];
                break;

            //sets the middle lane to be the default
            default:
                transform.position = _gameLanes[1];
                return;

        }
    }

    void SetPlayerLane(int laneNumber)
    {

    }
}
