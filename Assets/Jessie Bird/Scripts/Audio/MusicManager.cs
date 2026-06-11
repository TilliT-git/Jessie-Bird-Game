using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [Header("Music")]
    [SerializeField] private AudioSource _musicManager;
    [SerializeField] private AudioClip _musicGame;

    private void Awake()
    {
        Application.targetFrameRate = 120;
        _musicManager.volume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        _musicManager.clip = _musicGame;
        _musicManager.loop = true;
        _musicManager.Play();
    }

    public void UpdateMusicVolume(float value)
    {
        _musicManager.volume = Mathf.Clamp01(value);
    }
}
