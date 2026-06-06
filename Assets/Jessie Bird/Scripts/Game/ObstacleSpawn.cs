using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    [Header("Obstacle")]
    [SerializeField] private GameObject _obstacle;

    [Header("Obstacle Settings")]
    [SerializeField] private float _spawnPosX;
    [SerializeField] private float _spawnPosZ;
    [SerializeField] private float _minHeightY;
    [SerializeField] private float _maxHeightY;
    [SerializeField] private float _spawnRate;

    [Header("Time")]
    private float _timer = 0f;

    private void Update()
    {
        if (_timer >= _spawnRate)
        {
            _timer = 0f;
            SpawnObstacle();
        }
        else
        {
            _timer += Time.deltaTime;
        }
    }

    private void SpawnObstacle()
    {
        float randomPosY = Random.Range(_minHeightY, _maxHeightY);
        Vector3 spawnPos = new Vector3(_spawnPosX, randomPosY, _spawnPosZ);
        Instantiate(_obstacle, spawnPos, _obstacle.transform.rotation);
    }
}