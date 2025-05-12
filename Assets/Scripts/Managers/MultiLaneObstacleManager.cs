using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiLaneObstacleManager : MonoBehaviour
{
    public LaneManager _laneManager;

    [SerializeField]
    private float _obstacleSpeed = 5.0f;

    void Start()
    {
        _laneManager.SetupGameLanes();
        _laneManager.SetObstacleLane(2);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.back * _obstacleSpeed) * Time.deltaTime;
    }
}
