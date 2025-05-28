using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleUpdateManager : MonoBehaviour
{
    public LaneManager _laneManager;

    [SerializeField]
    private float _collectibleSpeed = 6.0f;

    public float GetCollectibleSpeed()
    {
        return _collectibleSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
