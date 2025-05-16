using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerLivesBehavior : MonoBehaviour
{
    [SerializeField]
    private int _lives;

    [SerializeField]
    private float _invincibilityFramesDuration;

    private float _invincibilityFramesTimer;

    public UnityEvent OnLifeLost;

    public UnityEvent OnAllLivesLost;


    public int Lives { get => _lives; }

    private void Update()
    {
        if (_invincibilityFramesTimer > 0)
            _invincibilityFramesTimer -= Time.deltaTime;
    }

    public void LoseLife()
    {
        // Decrement lives, then invoke OnAllLivesLost if lives are less than or equal to 0, or OnLifeLost if not. 
        _lives--;
        
        if (_lives <= 0)
        {
            OnAllLivesLost.Invoke();
        }
        else
        {
            OnLifeLost.Invoke();
            _invincibilityFramesTimer = _invincibilityFramesDuration;
        }
    }

    public void Hurt(Collision collision)
    {
        // Guard clause
        if (_invincibilityFramesTimer > 0)
            return;

        if (collision.gameObject.tag == "Obstacle")
            LoseLife();
    }
}
