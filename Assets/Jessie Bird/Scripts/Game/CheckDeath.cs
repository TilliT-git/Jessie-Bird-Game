using UnityEngine;

public class CheckDeath : MonoBehaviour
{
    [Header("Player Rigitbody")]
    private Rigidbody _playerRb;

    [Header("Death UI")]
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private GameObject _scoreText;

    [Header("Death Borders")]
    [SerializeField] private float _minHeightY;
    [SerializeField] private float _maxHeightY;

    [Header("Boolean Values")]
    public bool _isDeath = false;

    [Header("Actions")]
    public System.Action OnPlayerDeath;

    private void Awake()
    {
        _playerRb = GetComponent<Rigidbody>();
        Time.timeScale = 1f; 
    }

    private void Update()
    {
        if (!_isDeath && (_playerRb.transform.position.y < _minHeightY || _playerRb.transform.position.y > _maxHeightY))
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Time.timeScale = 0f;
        _gameOverScreen.SetActive(true);
        _scoreText.SetActive(false);
        OnPlayerDeath?.Invoke();
        _isDeath = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameOver();
        }
    }
}