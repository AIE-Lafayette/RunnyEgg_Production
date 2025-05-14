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

    //Fields for the seconds that determine spawn rates
    [SerializeField]
    private float _obstacleStartDelay = 5;
    [SerializeField]
    private float _obstacleSpawnInterval = 4;

    [SerializeField]
    private bool _isGameStarted = true;

    private int _index;

    int GetRandomIndex()
    {
        int indexOutput = Random.Range(0, _obstaclePrefabs.Length);
        return indexOutput;
    }

    void MoveObstacles(int positionIndex)
    {
        _obstaclePrefabs[positionIndex].transform.position = transform.position + (Vector3.back * _obstacleSpeed) * Time.deltaTime;
    }

    void SpawnObstacles()
    {
        _index = GetRandomIndex();
        Instantiate(_obstaclePrefabs[_index], _laneManager.GetRandomLane(), _obstaclePrefabs[_index].transform.rotation);
        
    }

    void Start()
    {
        if (_isGameStarted == true)
        {
            InvokeRepeating("SpawnObstacles", _obstacleStartDelay, _obstacleSpawnInterval);
        }

    }

    void Update()
    {
        MoveObstacles(_index);
    }
}
