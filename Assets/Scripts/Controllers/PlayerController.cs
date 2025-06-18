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

    private float _groundCheckDelay = 0.25f;

    Rigidbody _rigidbody;

    private Vector2 _moveDirection;

    private bool _moveInputtedThisFrame;

    private bool _jumpInputted;

    private bool _isGrounded;

    private float _groundCheckTimer;

    public UnityEvent OnLeftInput;

    public UnityEvent OnRightInput;

    public UnityEvent OnJumpInput;

    public UnityEvent OnLanding;

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
        if (_groundCheckTimer >= 0.0f)
            _groundCheckTimer -= Time.deltaTime;

        // record inputs
        _moveDirection = _moveInput.action.ReadValue<Vector2>();
        _moveInputtedThisFrame = _moveInput.action.WasPressedThisFrame();
        _jumpInputted = _jumpInput.action.IsPressed();

        // if the player inputted left or right, call the relevant UnityEvent
        if (_moveInputtedThisFrame && _moveDirection.x < 0)
        {
            OnLeftInput.Invoke();
        }
        else if (_moveInputtedThisFrame && _moveDirection.x > 0)
        {
            OnRightInput.Invoke();
        }
    }

    private void FixedUpdate()
    {
        // check if player is touching the ground
        bool rayResult = Physics.Raycast(transform.position + Vector3.down, transform.TransformDirection(Vector3.down), 0.2f, LayerMask.GetMask("Floor"));

        // if the player is really grounded and the ground check timer is done and the grounded bool is wrong, set isGrounded to true
        if (_groundCheckTimer <= 0.0f && !_isGrounded && rayResult)
        {
            _isGrounded = true;
            OnLanding.Invoke();
        }
        // otherwise, if the player is grounded and jump has been inputted, jump and set isGrounded to false
        else if (_isGrounded && _jumpInputted)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.VelocityChange);
            _isGrounded = false;
            _groundCheckTimer = _groundCheckDelay;
            OnJumpInput.Invoke();
        }
    }
}
