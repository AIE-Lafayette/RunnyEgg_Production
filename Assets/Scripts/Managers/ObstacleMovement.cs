using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{

    [SerializeField]
    private float _obstacleSpeed = 5.0f;

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
    }
}
