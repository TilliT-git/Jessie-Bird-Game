using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] private MusicManager _musicManager;
    [SerializeField] private SFXManager _sfxManager;

    [Header("UI Icons")]
    [SerializeField] private Image _musicIcon;
    [SerializeField] private Image _sfxIcon;
    [SerializeField] private Sprite _soundOnSprite;
    [SerializeField] private Sprite _soundOffSprite;

    [Header("Sliders")]
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _sfxSlider;

    private void Awake()
    {
        _musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
        _sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);

        UpdateMusicIcon(_musicSlider.value);
        UpdateSFXIcon(_sfxSlider.value);

        _musicSlider.onValueChanged.AddListener(SetMusicVolume);
        _sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    private void SetMusicVolume(float value)
    {
        _musicManager.UpdateMusicVolume(value);
        PlayerPrefs.SetFloat("MusicVolume", value);
        UpdateMusicIcon(_musicSlider.value);
    }

    private void SetSFXVolume(float value)
    {
        _sfxManager.UpdateSFXVolume(value);
        PlayerPrefs.SetFloat("SFXVolume", value);
        UpdateSFXIcon(_sfxSlider.value);
    }

    private void UpdateMusicIcon(float value)
    {
        if (_musicIcon != null)
        {
            _musicIcon.sprite = value > 0.01f ? _soundOnSprite : _soundOffSprite;
        }
    }

    private void UpdateSFXIcon(float value)
    {
        if (_sfxIcon != null)
        {
            _sfxIcon.sprite = value > 0.01f ? _soundOnSprite : _soundOffSprite;
        }
    }
}