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
        //Generates an interger that determines which obstacle prefab spawns in this instance of the function
        int index = GetRandomIndex();
        Vector3 obstaclePosition = new Vector3();

        if (_obstaclePrefabs[index].CompareTag("MiddleFillingObstacle"))
        {
            obstaclePosition = _laneManager.GetMiddleLaneStartPos();
        }
        else if (_obstaclePrefabs[index].CompareTag("Obstacle"))
        {
            obstaclePosition = _laneManager.GetRandomSpawnLane();
        }

        Instantiate(_obstaclePrefabs[index], obstaclePosition, _obstaclePrefabs[index].transform.rotation);
    }

    void Start()
    {
        if (_isGameStarted == true)
        {
            InvokeRepeating("SpawnObstacles", _obstacleStartDelay, _obstacleSpawnInterval);
        }
    }
}
