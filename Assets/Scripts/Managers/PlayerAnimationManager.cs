using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    [SerializeField]
    private PlayerController _playerController;

    [SerializeField]
    private PlayerLivesBehavior _playerLives;

    [SerializeField]
    private TitleScreenManager _titleScreenManager;

    private Animator _animator;

    private void Awake()
    {
        if (TryGetComponent(out Animator animator))
            _animator = animator;
    }

    private void Start()
    {
        // set up all the states to be set on their given conditions
        _titleScreenManager.OnGameStart.AddListener(StartRunning);
        _playerController.OnJumpInput.AddListener(StartJumping);
        _playerController.OnLanding.AddListener(StopJumping);
        _playerLives.OnLifeLost.AddListener(Hit);
        _playerLives.OnAllLivesLost.AddListener(StartDying);
    }

    private void StartRunning()
    {
        _animator.SetBool("IsRunning", true);
    }

    private void StartJumping()
    {
        _animator.SetBool("IsJumping", true);
    }

    private void StopJumping()
    {
        _animator.SetBool("IsJumping", false);
    }

    private void Hit()
    {
        _animator.SetBool("IsHit", true);
        Invoke("UnHit", 0.5f);
    }

    private void UnHit()
    {
        _animator.SetBool("IsHit", false);
    }

    private void StartDying()
    {
        _animator.SetBool("IsDead", true);
    }
}
