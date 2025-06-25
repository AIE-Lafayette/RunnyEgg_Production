using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsManager : MonoBehaviour
{
    [SerializeField]
    private Button _creditsButton;

    [SerializeField]
    private GameObject _creditsText;

    [SerializeField]
    private Button _startButton;

    [SerializeField]
    private float _creditsSpeed = 25.0f;

    [SerializeField]
    [Tooltip("Speed for the credits leaving. The credits will accelerate over time when leaving.")]
    private float _creditsExitSpeed = 5.0f;



    private RectTransform _creditsTextTransform;

    private bool _creditsStarted = false;

    private bool _creditsCancelled = false;

    private float _currentCreditsSpeed = 0;

    private void Start()
    {
        _creditsButton.onClick.AddListener(StartCredits);
        _startButton.onClick.AddListener(CancelCredits);

        _creditsTextTransform = _creditsText.GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (!_creditsStarted || !_creditsText)
            return;



        if (_creditsCancelled)
            _currentCreditsSpeed -= _creditsExitSpeed * Time.deltaTime;

        Vector3 newCreditsPosition = _creditsText.transform.position;

        newCreditsPosition.y += _currentCreditsSpeed * Time.deltaTime;

        _creditsText.transform.position = newCreditsPosition;

        // if the credits text is out of bounds, destroy it and prevent further updates
        if (Mathf.Abs(_creditsText.transform.position.y) > _creditsTextTransform.rect.height + 25)
        {
            _creditsStarted = false;
            Destroy(_creditsText);
        }
    }

    private void StartCredits()
    {
        _currentCreditsSpeed = _creditsSpeed;
        _creditsButton.interactable = false;
        _creditsStarted = true;
    }

    private void CancelCredits()
    {
        _creditsCancelled = true;
    }
}
