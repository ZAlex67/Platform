using UnityEngine;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private PauseUI _pauseMenu;
    [SerializeField] private  AudioMixerGroup _mixer;

    private bool _isPoused = false;
    private float _minVolume = -80f;
    private float _maxVolume = 0f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isPoused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void ToggleMusic(bool enabled)
    {
        if (enabled)
        {
            _mixer.audioMixer.SetFloat("MusicVolume", _maxVolume);
        }
        else
        {
            _mixer.audioMixer.SetFloat("MusicVolume", _minVolume);
        }
    }

    public void ChangeVolume(float volume)
    {
        _mixer.audioMixer.SetFloat("MasterVolume", Mathf.Lerp(_minVolume, _maxVolume, volume));
    }

    public void Resume()
    {
        _pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1f;
        _isPoused = false;
    }

    private void Pause()
    {
        _pauseMenu.gameObject.SetActive(true);
        Time.timeScale = 0f;
        _isPoused = true;
    }
}