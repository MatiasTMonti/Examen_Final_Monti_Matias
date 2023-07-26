using UnityEngine;
using UnityEngine.UI;
using System;

namespace tankDefend
{
    public class AudioUI : MonoBehaviour
    {
        public Action<float> OnChangeMuteToggle;

        [SerializeField] private Toggle mute;

        private bool isMuted;
        private float volume;

        private void Start()
        {
            volume = PlayerPrefs.GetFloat("volume", 1f);
            mute.isOn = volume == 0f;

            OnChangeMuteToggle?.Invoke(volume);
        }

        public void SetIsMuted()
        {
            if (mute.isOn)
            {
                OnChangeMuteToggle?.Invoke(0f);
                isMuted = true;
                volume = 0f;
            }
            else
            {
                OnChangeMuteToggle?.Invoke(1f);
                isMuted = false;
                volume = 1f;
            }

            PlayerPrefs.SetFloat("volume", volume);
        }

        public bool GetIsMuted()
        {
            return isMuted;
        }

        public void SetVolume(float volume)
        {
            this.volume = volume;
        }
    }
}