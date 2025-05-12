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

    [SerializeField]
    private float _jumpForce = 10.0f;

    Rigidbody _rigidbody;

    private Vector2 _moveDirection;

    private bool _moveInputtedThisFrame;

    private bool _jumpInputted;

    private bool _isGrounded;

    public UnityEvent LeftInput;

    public UnityEvent RightInput;

    private void Awake()
    {
        if (TryGetComponent(out Rigidbody rigidbody))
            _rigidbody = rigidbody;
    }

    private void Start()
    {
        _isGrounded = true;
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
        if (!_isGrounded)
        {
            if (Physics.Raycast(transform.position, Vector3.down, 20.0f, LayerMask.NameToLayer("Floor")))
                _isGrounded = true;
        }
        else if (_jumpInputted)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.VelocityChange);
            _isGrounded = false;
        }
    }
}
