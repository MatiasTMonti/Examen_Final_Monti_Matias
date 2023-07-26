using System.Collections.Generic;
using UnityEngine;

namespace tankDefend
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioSource musicSource;
        [SerializeField] private AudioSource buttonClickSFXSource;
        [SerializeField] private AudioSource shootSFXSource;
        [SerializeField] private AudioSource loseSFXSource;

        public static AudioManager instance;

        private void Awake()
        {
            if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy(gameObject);

            DontDestroyOnLoad(gameObject);
        }

        public void PlayMusic(AudioClip musicClip)
        {
            musicSource.clip = musicClip;
            musicSource.Play();
        }

        public void PlayButtonClickSFX(AudioClip sfxClip)
        {
            buttonClickSFXSource.PlayOneShot(sfxClip);
        }

        public void PlayShootSFX(AudioClip sfxClip)
        {
            shootSFXSource.PlayOneShot(sfxClip);
        }

        public void PlayLoseSFX(AudioClip sfxClip)
        {
            loseSFXSource.PlayOneShot(sfxClip);
        }

        public void SetMusicVolume(float volume)
        {
            musicSource.volume = volume;
        }

        public void SetSFXVolume(float volume)
        {
            buttonClickSFXSource.volume = volume;
            shootSFXSource.volume = volume;
            loseSFXSource.volume = volume;
        }

        public float GetMusicVolume()
        {
            return musicSource.volume;
        }

        public float GetSFXVolume()
        {
            return buttonClickSFXSource.volume;
        }

        public void MuteAllAudio(bool isMuted)
        {
            AudioListener.pause = isMuted;
        }
    }
}