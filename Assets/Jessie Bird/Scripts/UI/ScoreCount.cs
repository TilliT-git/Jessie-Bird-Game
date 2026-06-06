using TMPro;
using UnityEngine;

public class ScoreCount : MonoBehaviour
{
    [Header("Score Text")]
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _recordText;

    [Header("Score Counts")]
    private int _currentScore;
    private int _highScore;

    void Start()
    {
        _highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateScoreUI();
    }

    public void AddToScore(int value)
    {
        _currentScore += value;

        if (_currentScore > _highScore)
        {
            _highScore = _currentScore;
            PlayerPrefs.SetInt("HighScore", _highScore);
            PlayerPrefs.Save();
            UpdateScoreUI();
        }

        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (_scoreText != null)
        {
            _scoreText.text = "Score:" + _currentScore;
        }

        if (_recordText != null)
        {
            _recordText.text = "Record:" + _highScore;
        }
    }

    public void ResetRecord()
    {
        PlayerPrefs.DeleteKey("HighScore");
        _highScore = 0;
        UpdateScoreUI();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Count Trigger"))
        {
            AddToScore(1);
        }
    }
}