using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class CollectibleSpawnManager : MonoBehaviour
{
    public LaneManager _laneManager;

    public GameObject[] _collectiblePrefabs;

    [SerializeField]
    private float _collectibleStartDelay = 3;
    [SerializeField]
    private float _collectibleSpawnInterval = 1;

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

    public Vector3 SetCollectibleLane()
    {
        Vector3 determinedLane = new Vector3();

        determinedLane = _laneManager.GetRandomSpawnLane();

        return determinedLane;
    }

    private void SpawnCollectibles()
    {
        int index = GetRandomCollectibleIndex();

        Instantiate(_collectiblePrefabs[index], SetCollectibleLane(), _collectiblePrefabs[index].transform.rotation);
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
