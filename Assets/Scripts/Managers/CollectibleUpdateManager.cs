using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleUpdateManager : MonoBehaviour
{
    public ScoreManager ScoreManagerr;

    public LaneManager LaneManager;

    public bool _isPrefab = true;

    [SerializeField]
    private float _collectibleSpeed = 6.0f;

    [SerializeField]
    private float _scoreIncreaseAmount = 50.0f;

    public float GetCollectibleSpeed()
    {
        return _collectibleSpeed;
    }

    private void MoveCollectible()
    {
        transform.position = transform.position + (Vector3.back * GetCollectibleSpeed()) * Time.deltaTime;
    }

    private void Start()
    {
        if (!_isPrefab)
        {
            CollectibleUpdateManager collectible = GetComponentInParent<CollectibleUpdateManager>();
            if (collectible)
            {
                collectible.ScoreManagerr = ScoreManagerr;
                collectible.LaneManager = LaneManager;
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        //If this instance of the script is not a prefab, run Update normally
        if (!_isPrefab)
        {
            MoveCollectible();

            if (transform.position.z <= LaneManager.GetDestroyZone())
            {
                Destroy(gameObject);
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
         ScoreManagerr.AddScore(_scoreIncreaseAmount);
        Destroy(gameObject);
    }
}
