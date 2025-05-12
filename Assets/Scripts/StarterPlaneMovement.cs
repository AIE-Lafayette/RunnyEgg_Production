using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarterPlaneMovement : MonoBehaviour
{
    [SerializeField]
    private Vector3 _haltPosition;

    public void Update()
    {
        Vector3 newPosition = transform.position;

        newPosition += Vector3.back * Time.deltaTime;
    }
}
