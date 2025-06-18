using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class CollectibleSpawnManager : MonoBehaviour
{
    // score manager reference to give to collectibles
    [SerializeField]
    private ScoreManager _scoreManager;

    public LaneManager _laneManager;

    [SerializeField]
    private GameObject[] _collectiblePrefabs;

    [SerializeField]
    private Transform[] _obstaclePositions;

    [SerializeField]
    private float _collectibleStartDelay = 3;
    [SerializeField]
    private float _collectibleSpawnInterval = 3;

    [SerializeField]
    private bool _isGameStarted = true;

    public float GetCollectibleStartDelay()
    {
        return _collectibleStartDelay;
    }

    public float GetCollectibleSpawnInterval()
    {
        return _collectibleSpawnInterval;
    }

    private int GetRandomCollectibleIndex()
    {
        int indexOutput = Random.Range(0, _collectiblePrefabs.Length);
        return indexOutput;
    }

    public Vector3 SetCollectibleLane(int index)
    {
        Vector3 determinedLane = new Vector3();

        if (_collectiblePrefabs[index].CompareTag("SmallCollectible"))
        {
            for (int i = 0; i < _obstaclePositions.Length; i++)
            {
                //Checks if an obstacle is in the right-side lane and is moving adjacent to the collectible prefab.
                //These checks find out if the x position is greater than or less than 0 due to the bread loaf obstacle being offset from any static lanes
                if (_obstaclePositions[i].position.x > 0 && _obstaclePositions[i].position.z == _collectiblePrefabs[index].transform.position.z)
                {
                    //Then ensures that the collectible's spawn lane is set to be in lanes other than the right-side lane
                    determinedLane = _laneManager.GetMiddleOrLeftLaneSpawns();
                }
                //Checks if an obstacle is in the left-side lane and is moving adjacent to the collectible prefab.
                else if (_obstaclePositions[i].position.x < 0 && _obstaclePositions[i].position.z == _collectiblePrefabs[index].transform.position.z)
                {
                    //Then ensures that the collectible's spawn lane is set to be in lanes other than the left-side lane
                    determinedLane = _laneManager.GetMiddleOrRightLaneSpawns();
                }
                //Checks if an obstacle is in the middle lane and is moving adjacent to the collectible prefab.
                else if (_obstaclePositions[i].position.x == 0 && _obstaclePositions[i].position.z == _collectiblePrefabs[index].transform.position.z)
                {
                    //Then ensures that the collectible's spawn lane is set to be in lanes other than the middle lane
                    determinedLane = _laneManager.GetLeftOrRightLaneSpawns();
                }
            }
        }

        determinedLane = _laneManager.GetRandomSpawnLane();

        return determinedLane;
    }

    private void SpawnCollectibles()
    {
        int index = GetRandomCollectibleIndex();

        GameObject collectible = Instantiate(_collectiblePrefabs[index], SetCollectibleLane(index), _collectiblePrefabs[index].transform.rotation);

        if (collectible.TryGetComponent(out CollectibleUpdateManager c))
        {
            c.ScoreManagerr = _scoreManager;
            c.LaneManager = _laneManager;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (_isGameStarted == true)
        {
            InvokeRepeating("SpawnCollectibles", GetCollectibleStartDelay(), GetCollectibleSpawnInterval());
        }

    }

}
