using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    private AudioSource _audioSource;

    [Space(10)]

    [SerializeField]
    private TitleScreenManager _titleManager;

    [SerializeField]
    private PlayerLivesBehavior _playerLives;

    private bool _isGameOver;

    private float _pitchAndVolumeModifier = 0.0f;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        _titleManager.OnGameStart.AddListener(delegate { _audioSource.Play(); });
        _playerLives.OnAllLivesLost.AddListener(delegate { _isGameOver = true; });
    }

    private void Update()
    {
        if (_isGameOver && _pitchAndVolumeModifier <= 0.0f)
        {
            _pitchAndVolumeModifier = Mathf.Lerp(_pitchAndVolumeModifier, 0.0f, Time.deltaTime);
            _audioSource.pitch = _pitchAndVolumeModifier;
            _audioSource.volume = _pitchAndVolumeModifier;
        }
    }
}
