using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _laneWidth;
    private void Update()
    {

    }

    public void Move(InputAction.CallbackContext context)
    {
        InputControl input = context.control;
    }
}
