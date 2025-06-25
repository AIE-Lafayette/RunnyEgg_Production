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

        determinedLane = _laneManager.GetRandomSpawnLane();

        return determinedLane;
    }

    private void SpawnCollectibles()
    {
        int index = GetRandomCollectibleIndex();

        Vector3 elevationModifier = new Vector3(0, 2.7f, 0);
        LayerMask layerMask = LayerMask.GetMask("Obstacle");

        GameObject collectible = Instantiate(_collectiblePrefabs[index], SetCollectibleLane(index), _collectiblePrefabs[index].transform.rotation);
        Vector3 raycastStartOffset = new Vector3(0, 5, 0);
        Vector3 raycastStartVector = collectible.transform.position + raycastStartOffset;
        Vector3 raycastEndVector = collectible.transform.position + collectible.transform.TransformDirection(Vector3.down) * 10.0f;
        Vector3 rayDir = collectible.transform.TransformDirection(Vector3.down);
        float rayDistance = 25.0f;
        RaycastHit hit;
        if (Physics.Raycast(raycastStartVector, rayDir, out hit, rayDistance, layerMask))
        {
            if (hit.collider.gameObject.CompareTag("BurnerObstacle"))
            {
                Destroy(collectible);
            }
            if (hit.collider.gameObject.CompareTag("FlourSackObstacle"))
            {
                Destroy(collectible);
            }

            collectible.transform.position = collectible.transform.position + elevationModifier;
        }

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
