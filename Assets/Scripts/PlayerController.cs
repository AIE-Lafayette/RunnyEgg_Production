using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _laneWidth;

    private PlayerInput _playerInput;

    private void Awake()
    {
        if (TryGetComponent(out PlayerInput playerInput))
            _playerInput = playerInput;
        else
            Debug.Log("PlayerController: No PlayerInput component!");
    }

    private void Update()
    {

    }

    public void MoveLeft()
    {

    }
}
