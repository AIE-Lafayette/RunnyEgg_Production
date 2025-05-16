using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private double _score = 0;

    [SerializeField]
    private double _scoreIncreaseByTime;

    [SerializeField]
    private float _scoreIncreaseDelay;

    private float _scoreIncreaseTimer;

    public double Score { get => _score; }

    public void AddScore(double score) { _score += score; }

    private void Start()
    {
        _scoreIncreaseTimer = _scoreIncreaseDelay;
    }

    private void Update()
    {
        if (_scoreIncreaseTimer <= 0)
        {
            AddScore(_scoreIncreaseByTime);
            _scoreIncreaseTimer = _scoreIncreaseDelay;
        }
        else
            _scoreIncreaseTimer -= Time.deltaTime;


        Debug.Log("Score: " + _score);
    }
}
