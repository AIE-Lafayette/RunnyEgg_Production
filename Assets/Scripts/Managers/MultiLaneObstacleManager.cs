using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiLaneObstacleManager : MonoBehaviour
{
    //Instance of the LaneManager class to make use of the lane positions
    public LaneManager _laneManager;

    public GameObject[] _obstaclePrefabs;

    [SerializeField]
    private float _obstacleSpeed = 5.0f;

    [SerializeField]
    private float _obstacleStartDelay = 5.0f;

    [SerializeField]
    private float _obstacleSpawnInterval = 4.0f;

    private bool _isGameStarted = false;

    void SpawnObstacles()
    {
        _laneManager.SetupGameLanes();
        int obstacleIndex = Random.Range(0, _obstaclePrefabs.Length);

        //int spawnPositionIndex = Random.Range(0, _laneManager._laneAmount + 1);
        //Vector3 spawnPosition = new Vector3(_laneSpawnPositions[spawnPositionIndex].x, _laneSpawnPositions[spawnPositionIndex].y, _laneSpawnPositions[spawnPositionIndex].z);
        //Instantiate()
    }

    void MoveObstacles()
    {
        transform.position = transform.position + (Vector3.back * _obstacleSpeed) * Time.deltaTime;
    }

    void Start()
    {
        if (_isGameStarted == false)
        {
            _isGameStarted = true;
            InvokeRepeating("SpawnObstacles", _obstacleStartDelay, _obstacleSpawnInterval);
        }

    }

    void Update()
    {
        MoveObstacles();
    }
}
