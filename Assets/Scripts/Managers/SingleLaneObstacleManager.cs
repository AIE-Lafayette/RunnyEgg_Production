using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleLaneObstacleManager : MonoBehaviour
{
    public LaneManager _laneManager;

    [SerializeField]
    private float _obstacleSpeed = 5.0f;

    void Start()
    {
        _laneManager.SetupGameLanes();
        _laneManager.SetObstacleLane(Random.Range(1,4));
    }

    void Update()
    {
        transform.position = transform.position + (Vector3.back * _obstacleSpeed) * Time.deltaTime;
    }
}
