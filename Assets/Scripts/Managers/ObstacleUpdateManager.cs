using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleUpdateManager : MonoBehaviour
{
    //Sets the speed at which the obstacles move towards the camera
    [SerializeField]
    private float _obstacleSpeed = 5.0f;

    //Sets the area behind the camera as the spot where obstacles are removed
    private Vector3 _destroyZone = new Vector3(0, 0, -5);

    public float GetObstacleSpeed()
    {
        return _obstacleSpeed;
    }

    public float GetDestroyZone()
    {
        return _destroyZone.z;
    }

    void MoveObstacle()
    {
        transform.position = transform.position + (Vector3.back * GetObstacleSpeed()) * Time.deltaTime;
    }

    void Update()
    {
        MoveObstacle();

        //Removes the obstacle if it reaches or passes beyond the destroy zone
        if (transform.position.z <= GetDestroyZone())
        {
            Destroy(gameObject);
        }
    }
}
