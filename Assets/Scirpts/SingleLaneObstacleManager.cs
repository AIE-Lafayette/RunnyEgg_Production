using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleLaneObstacleManager : MonoBehaviour
{
    public LaneManager _laneManager;

    void Start()
    {
        _laneManager.SetupGameLanes();
        _laneManager.SetObstacleLane(Random.Range(1,4));
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position;

        newPosition += Vector3.back * Time.deltaTime;
    }
}
