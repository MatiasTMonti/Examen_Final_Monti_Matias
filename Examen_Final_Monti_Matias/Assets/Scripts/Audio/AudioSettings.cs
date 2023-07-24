using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSettings : MonoBehaviour
{
    private const string musicVolumeKey = "MusicVolume";
    private const string sFXVolumeKey = "SFXVolume";
    private const string isMutedKey = "IsMuted";

    public static void SaveAudioSettings(float musicVolume, float sfxVolume, bool isMuted)
    {
        PlayerPrefs.SetFloat(musicVolumeKey, musicVolume);
        PlayerPrefs.SetFloat(sFXVolumeKey, sfxVolume);
        PlayerPrefs.SetFloat(isMutedKey, isMuted ? 1 : 0);
    }

    public static float GetMusicVolume()
    {
        return PlayerPrefs.GetFloat(musicVolumeKey, 1f);
    }

    public static float GetSFXVolume()
    {
        return PlayerPrefs.GetFloat(sFXVolumeKey, 1f);
    }

    public static bool IsAudioMuted()
    {
        return PlayerPrefs.GetInt(isMutedKey, 0) == 1;
    }
}
