using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleUpdateManager : MonoBehaviour
{
    //Instance of the LaneManager to get the destroy zone for obstacle despawning
    public LaneManager _laneManager;

    //Sets the speed at which the obstacles move towards the camera
    [SerializeField]
    private float _obstacleSpeed = 6.0f;

    public float GetObstacleSpeed()
    {
        return _obstacleSpeed;
    }

    void MoveObstacle()
    {
        transform.position = transform.position + (Vector3.back * GetObstacleSpeed()) * Time.deltaTime;
    }

    void Update()
    {
        MoveObstacle();

        //Removes the obstacle if it reaches or passes beyond the destroy zone
        if (transform.position.z <= _laneManager.GetDestroyZone())
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerLivesBehavior playerLives))
            playerLives.Hurt();

    }
}
