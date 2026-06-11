using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private ScoreCount _scoreCount;
    [SerializeField] private CheckDeath _checkDeath;

    [Header("Canvas")]
    [SerializeField] private Canvas _mainCanvas;

    [Header("Screens")]
    [SerializeField] private GameObject _pauseScreen;
    [SerializeField] private GameObject _settingsScreen;
    [SerializeField] private GameObject _recordResetScreen;
    [SerializeField] private GameObject _scoreText;

    [Header("Boolean Values")]
    private bool _isPause = false;

    [Header("Actions")]
    public System.Action OnButtonClick;
    public System.Action OnPauseGame;
    public System.Action OnResumeGame;

    public void LoadGameScene()
    {
        OnButtonClick?.Invoke();
        SceneManager.LoadScene("Game Scene");
    }

    public void PauseGame()
    {
        if (_checkDeath._isDeath) return;

        _isPause = !_isPause;
        OnButtonClick?.Invoke();
        OnPauseGame?.Invoke();

        if (_isPause)
        {
            Time.timeScale = 0f;
            _pauseScreen.SetActive(true);
            _scoreText.SetActive(false);
        }
        else
        {
            Time.timeScale = 1f;
            _pauseScreen.SetActive(false);
            _settingsScreen.SetActive(false);
            _scoreText.SetActive(true);
        }
    }

    public void SettingsScreen()
    {
        OnButtonClick?.Invoke();
        _pauseScreen.SetActive(false);
        _settingsScreen.SetActive(true);
    }

    public void SettingsScreenBack()
    {
        OnButtonClick?.Invoke();
        _pauseScreen.SetActive(true);
        _settingsScreen.SetActive(false);
    }

    public void RestartGame()
    {
        OnButtonClick?.Invoke();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ShowResetConfirm()
    {
        OnButtonClick?.Invoke();
        _recordResetScreen.SetActive(true);
    }

    public void ConfirmReset()
    {
        OnButtonClick?.Invoke();
        _scoreCount.ResetRecord();
        _recordResetScreen.SetActive(false);
    }

    public void CancelReset()
    {
        OnButtonClick?.Invoke();
        _recordResetScreen.SetActive(false);
    }
}
