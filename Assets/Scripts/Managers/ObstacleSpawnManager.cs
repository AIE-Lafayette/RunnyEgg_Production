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

    public float GetObstacleStartDelay()
    {
        return _obstacleStartDelay;
    }

    public float GetObstacleSpawnInterval()
    {
        return _obstacleSpawnInterval;
    }

    private int GetRandomObstacleIndex()
    {
        int indexOutput = Random.Range(0, _obstaclePrefabs.Length);
        return indexOutput;
    }


    //Sets an obstacle's lane to one of the three positions.
    //The parameter 'index' is used to determine the prefab that is checked by the if statements
    public Vector3 SetObstacleLane(int index)
    {
        Vector3 determinedLane = new Vector3();

        //If statements to determine three-lane filling obstacles' positions
        if (_obstaclePrefabs[index].CompareTag("EggCartonObstacle"))
        {
            determinedLane = _laneManager.GetMiddleLaneStartPos();
        }
        else if (_obstaclePrefabs[index].CompareTag("RollingPinObstacle"))
        {
            determinedLane = _laneManager.GetMiddleLaneStartPos();
        }

        //Obstacles with the BreadLoaf tag is an exception to being placed into one of three lanes, and is offset from the middle lane in order to occupy two lanes at once when instantiated
        else if (_obstaclePrefabs[index].CompareTag("BreadLoafObstacle"))
        {
            Vector3 baselineVector = _laneManager.GetMiddleLaneStartPos();
            Vector3 leftOffsetVector = Vector3.left * 2;
            Vector3 rightOffsetVector = Vector3.right * 2;

            //Generates an int that determines whether the obstacle is offset to the left or right of the middle lane
            int vectorDeterminer = Random.Range(1, 3);

            switch (vectorDeterminer)
            {
                case 1:
                    determinedLane = baselineVector + leftOffsetVector;
                    break;
                case 2:
                    determinedLane = baselineVector + rightOffsetVector;
                    break;
                //Being offset into the left lane is the default position
                default:
                    determinedLane = baselineVector + leftOffsetVector;
                    break;
            }

        }

        //If statements one-lane filling obstacles' positions
        else if (_obstaclePrefabs[index].CompareTag("BurnerObstacle"))
        {
            determinedLane = _laneManager.GetRandomSpawnLane();
        }
        else if (_obstaclePrefabs[index].CompareTag("FlourSackObstacle"))
        {
            determinedLane = _laneManager.GetRandomSpawnLane();
        }
        else if (_obstaclePrefabs[index].CompareTag("OilSpillObstacle"))
        {
            determinedLane = _laneManager.GetRandomSpawnLane();
        }

        return determinedLane;
    }

    private void SpawnObstacles()
    {
        //Generates an interger that determines which obstacle prefab spawns in this instance of the function
        int index = GetRandomObstacleIndex();

        Instantiate(_obstaclePrefabs[index], SetObstacleLane(index), _obstaclePrefabs[index].transform.rotation);
    }

    void Start()
    {
        if (_isGameStarted == true)
        {
            InvokeRepeating("SpawnObstacles", GetObstacleStartDelay(), GetObstacleSpawnInterval());
        }
    }
}
