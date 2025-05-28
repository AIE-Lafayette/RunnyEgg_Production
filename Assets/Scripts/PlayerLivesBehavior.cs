using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerLivesBehavior : MonoBehaviour
{
    [SerializeField]
    private int _lives;

    private float _invincibilityFramesDuration = 3.0f;

    private float _invincibilityFramesTimer;

    private bool _isDead = false;

    public UnityEvent OnLifeLost;

    public UnityEvent OnAllLivesLost;


    public int Lives { get => _lives; }

    public bool IsDead { get => _isDead; }

    private void Update()
    {
        if (_invincibilityFramesTimer > 0)
            _invincibilityFramesTimer -= Time.deltaTime;
    }

    private void LoseLife()
    {
        // Decrement lives, then invoke OnAllLivesLost if lives are less than or equal to 0, or OnLifeLost if not. 
        _lives--;
        
        if (_lives <= 0)
        {
            OnAllLivesLost.Invoke();
            _isDead = true;
        }
        else
        {
            OnLifeLost.Invoke();
        }

        _invincibilityFramesTimer = _invincibilityFramesDuration;
    }

    // if the player comes in contact with an obstacle and doesn't have invincibility frames, player loses a life
    private void OnCollisionEnter(Collision collision)
    {
        if (_invincibilityFramesTimer > 0)
            return;

        if (collision.gameObject.tag.Contains("Obstacle"))
            LoseLife();
    }
}
