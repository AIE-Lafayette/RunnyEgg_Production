using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleUpdateManager : MonoBehaviour
{
    public ScoreManager ScoreManagerr;

    public LaneManager LaneManager;

    [SerializeField]
    private float _collectibleSpeed = 6.0f;

    [SerializeField]
    private float _scoreIncreaseAmount = 50.0f;

    public float GetCollectibleSpeed()
    {
        return _collectibleSpeed;
    }

    private void MoveCollectible()
    {
        transform.position = transform.position + (Vector3.back * GetCollectibleSpeed()) * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        MoveCollectible();

        if (transform.position.z <= LaneManager.GetDestroyZone())
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        ScoreManagerr.AddScore(_scoreIncreaseAmount);
        Destroy(gameObject);
    }
}
