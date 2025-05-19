using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnManager : MonoBehaviour
{
    //Instance of the LaneManager class to make use of the lane positions
    public LaneManager _laneManager;

    public GameObject[] _obstaclePrefabs;

    //Fields for the seconds that determine spawn rates
    [SerializeField]
    private float _obstacleStartDelay = 5;
    [SerializeField]
    private float _obstacleSpawnInterval = 4;

    [SerializeField]
    private bool _isGameStarted = true;

    private int GetRandomIndex()
    {
        int indexOutput = Random.Range(0, _obstaclePrefabs.Length);
        return indexOutput;
    }

    private void SpawnObstacles()
    {
        int index = GetRandomIndex();
        Instantiate(_obstaclePrefabs[index], _laneManager.SetObstacleLane(), _obstaclePrefabs[index].transform.rotation);
    }

    void Start()
    {
        if (_isGameStarted == true)
        {
            InvokeRepeating("SpawnObstacles", _obstacleStartDelay, _obstacleSpawnInterval);
        }
    }
}
