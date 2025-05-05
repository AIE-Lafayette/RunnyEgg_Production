using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _laneWidth;

    [SerializeField]
    private InputActionReference _move;

    [SerializeField]
    private InputActionReference _jump;

    private Vector2 _moveDirection;

    private bool _moveInputtedThisFrame;

    private bool _jumpInputted;


    private void Start()
    {
        
    }

    private void Update()
    {
        // record inputs
        _moveDirection = _move.action.ReadValue<Vector2>();
        _moveInputtedThisFrame = _move.action.WasPressedThisFrame();
        _jumpInputted = _jump.action.IsPressed();

        Vector3 newPosition = gameObject.transform.position;
        // make player move
        if (_moveInputtedThisFrame && _moveDirection.x < 0)
        {
            newPosition.x -= _laneWidth;
        }
        else if (_moveInputtedThisFrame && _moveDirection.x > 0)
        {
            newPosition.x += _laneWidth;
        }
        gameObject.transform.position = newPosition;
    }

    private void FixedUpdate()
    {
        if (_jumpInputted)
            Debug.Log("JUMP");
    }
}
