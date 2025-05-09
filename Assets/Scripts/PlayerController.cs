using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private InputActionReference _moveInput;

    [SerializeField]
    private InputActionReference _jumpInput;

    private Vector2 _moveDirection;

    private bool _moveInputtedThisFrame;

    private bool _jumpInputted;

    public UnityEvent LeftInput;

    public UnityEvent RightInput;


    private void Start()
    {
        
    }

    private void Update()
    {
        // record inputs
        _moveDirection = _moveInput.action.ReadValue<Vector2>();
        _moveInputtedThisFrame = _moveInput.action.WasPressedThisFrame();
        _jumpInputted = _jumpInput.action.IsPressed();

        Vector3 newPosition = gameObject.transform.position;
        // make player move
        if (_moveInputtedThisFrame && _moveDirection.x < 0)
        {
            LeftInput.Invoke();
        }
        else if (_moveInputtedThisFrame && _moveDirection.x > 0)
        {
            RightInput.Invoke();
        }
        gameObject.transform.position = newPosition;
    }

    private void FixedUpdate()
    {
        if (_jumpInputted)
            Debug.Log("JUMP");
    }
}
