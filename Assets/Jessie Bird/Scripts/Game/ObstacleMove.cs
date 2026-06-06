using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    [Header("Obstacle Settings")]
    [SerializeField] private GameObject _obstacle;
    [SerializeField] private Vector3 _direction;
    [SerializeField] private float _destroyPos;
    [SerializeField] private float _speed;

    private void Update()
    {
        _obstacle.transform.Translate(_direction * _speed * Time.deltaTime);

        if (_obstacle.transform.position.x <= _destroyPos)
        {
            Destroy(_obstacle);
        }
    }
}