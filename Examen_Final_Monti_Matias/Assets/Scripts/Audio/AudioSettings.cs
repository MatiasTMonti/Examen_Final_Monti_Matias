using System;
using UnityEngine;

namespace tankDefend
{
    public class AudioSettings : MonoBehaviour
    {
        public Action<float> OnSetAudioSettings;
        public Action<float> OnReturnAudioSettings;

        private void Start()
        {
            OnReturnAudioSettings(GetAudioVolume());
        }
        public void SetAudioSettings(float volume)
        {
            PlayerPrefs.SetFloat("volume", volume);
            OnSetAudioSettings?.Invoke(volume);
        }

        public float GetAudioVolume()
        {
            return PlayerPrefs.GetFloat("volume", 0f);
        }
    }
}