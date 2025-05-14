using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private double _score = 0;

    [SerializeField]
    private double _distanceScoreIncreaseAmount;

    [SerializeField]
    private float _distanceScoreIncreaseDelay;

    private float _distanceScoreIncreaseTimer;

    public double Score { get => _score; }

    public void AddScore(double score) { _score += score; }

    private void Start()
    {
        _distanceScoreIncreaseTimer = _distanceScoreIncreaseDelay;
    }

    private void Update()
    {
        if (_distanceScoreIncreaseTimer <= 0)
        {
            AddScore(_distanceScoreIncreaseAmount);
            _distanceScoreIncreaseTimer = _distanceScoreIncreaseDelay;
        }
        else
            _distanceScoreIncreaseTimer -= Time.deltaTime;


        Debug.Log("Score: " + _score);
    }
}
