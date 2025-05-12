using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerLivesBehavior : MonoBehaviour
{
    public UnityEvent OnLifeLost;

    public UnityEvent OnAllLivesLost;

    [SerializeField]
    private int _lives;

    public int Lives { get => _lives; }

    public void LoseLife()
    {
        _lives--;
        
        if (_lives == 0)
        {
            OnAllLivesLost.Invoke();
        }
        else if (_lives > 0)
        {
            OnLifeLost.Invoke();
        }
    }
}
