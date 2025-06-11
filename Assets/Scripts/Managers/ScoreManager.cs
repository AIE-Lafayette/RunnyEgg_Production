using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private double _score = 0;

    [SerializeField]
    private double _scoreIncreaseAmount;

    [SerializeField]
    private float _scoreIncreaseDelay;

    private float _scoreIncreaseTimer;

    [SerializeField]
    private PlayerLivesBehavior _playerLives;

    public double Score { get => _score; }

    public void AddScore(double score) { _score += score; }

    private void Start()
    {
        _scoreIncreaseTimer = _scoreIncreaseDelay;

        if (_playerLives)
            _playerLives.OnAllLivesLost.AddListener(Disable);
    }

    private void Update()
    {
        if (_scoreIncreaseTimer <= 0)
        {
            AddScore(_scoreIncreaseAmount);
            _scoreIncreaseTimer = _scoreIncreaseDelay;
        }
        else
            _scoreIncreaseTimer -= Time.deltaTime;
    }

    private void Disable()
    {
        enabled = false;
    }
}
