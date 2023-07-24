using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioUI : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Toggle muteToggle;

    private void Start()
    {
        musicSlider.value = AudioSettings.GetMusicVolume();
        sfxSlider.value = AudioSettings.GetSFXVolume();
        muteToggle.isOn = AudioSettings.IsAudioMuted();
    }

    public void OnMusicVolumeChanged(float volume)
    {
        AudioManager.instance.SetMusicVolume(volume);
        AudioSettings.SaveAudioSettings(volume, AudioManager.instance.GetSFXVolume(), AudioSettings.IsAudioMuted());
    }

    public void OnSFXVolumeChanged(float volume)
    {
        AudioManager.instance.SetSFXVolume(volume);
        AudioSettings.SaveAudioSettings(AudioManager.instance.GetMusicVolume(), volume, AudioSettings.IsAudioMuted());
    }

    public void OnMuteToggle(bool isMuted)
    {
        AudioManager.instance.MuteAllAudio(isMuted);
        AudioSettings.SaveAudioSettings(AudioManager.instance.GetMusicVolume(), AudioManager.instance.GetSFXVolume(), isMuted);
    }
}
