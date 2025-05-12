using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public LaneManager _laneManager;

    void Start()
    {
        _laneManager.SetupGameLanes();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
