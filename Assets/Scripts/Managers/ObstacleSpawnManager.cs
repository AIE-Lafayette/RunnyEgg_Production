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


    //Sets an obstacle's lane to one of the three positions.
    //The parameter 'index' is used to determine the prefab that is checked by the if statements
    public Vector3 SetObstacleLane(int index)
    {
        Vector3 determinedLane = new Vector3();

        if (_obstaclePrefabs[index].CompareTag("ThreeLaneObstacle"))
        {
            determinedLane = _laneManager.GetMiddleLaneStartPos();
        }
        else if (_obstaclePrefabs[index].CompareTag("OneLaneObstacle"))
        {
            determinedLane = _laneManager.GetRandomSpawnLane();
        }

        return determinedLane;
    }

    private void SpawnObstacles()
    {
        //Generates an interger that determines which obstacle prefab spawns in this instance of the function
        int index = GetRandomIndex();

        Instantiate(_obstaclePrefabs[index], SetObstacleLane(index), _obstaclePrefabs[index].transform.rotation);
    }

    void Start()
    {
        if (_isGameStarted == true)
        {
            InvokeRepeating("SpawnObstacles", _obstacleStartDelay, _obstacleSpawnInterval);
        }
    }
}
