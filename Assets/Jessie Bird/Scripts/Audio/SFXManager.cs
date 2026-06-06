using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [Header("Connections to SFX Sounds")]
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private CheckDeath _checkDeath;
    [SerializeField] private ScreenManager _screenManager;

    [Header("SFX Sounds")]
    [SerializeField] private AudioSource sfxManager;
    [SerializeField] private AudioClip playerJump;
    [SerializeField] private AudioClip playerDeath;
    [SerializeField] private AudioClip gameOver;
    [SerializeField] private AudioClip click;

    private void Awake()
    {
        sfxManager.volume = PlayerPrefs.GetFloat("SFXVolume", 1f);
    }

    private void OnEnable()
    {
        if (sfxManager != null)
        {
            _playerController.OnPlayerJump += PlayJumpSound;
            _checkDeath.OnPlayerDeath += PlayDeathSound;
            _checkDeath.OnPlayerDeath += PlayGameOverSound;
            _screenManager.OnButtonClick += PlayClickSound;
        }
    }

    private void OnDisable()
    {
        if (sfxManager != null)
        {
            _playerController.OnPlayerJump -= PlayJumpSound;
            _checkDeath.OnPlayerDeath -= PlayDeathSound;
            _checkDeath.OnPlayerDeath -= PlayGameOverSound;
            _screenManager.OnButtonClick -= PlayClickSound;
        }
    }

    public void UpdateSFXVolume(float value)
    {
        if (value <= 0.1f) value = 0f;
        if (value >= 0.9f) value = 1f;
        sfxManager.volume = value;
    }

    private void PlayJumpSound() => sfxManager.PlayOneShot(playerJump);
    private void PlayDeathSound() => sfxManager.PlayOneShot(playerDeath);
    private void PlayGameOverSound() => sfxManager.PlayOneShot(gameOver);
    private void PlayClickSound() => sfxManager.PlayOneShot(click);
}
