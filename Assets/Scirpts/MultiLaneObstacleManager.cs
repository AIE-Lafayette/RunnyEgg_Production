using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiLaneObstacleManager : MonoBehaviour
{
    public LaneManager _laneManager;

    void Start()
    {
        _laneManager.SetupGameLanes();
        _laneManager.SetObstacleLane(2);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position;

        newPosition += Vector3.back * Time.deltaTime;
    }
}
