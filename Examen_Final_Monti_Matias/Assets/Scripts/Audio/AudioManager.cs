using UnityEngine;

namespace tankDefend
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager instance;

        [SerializeField] private AudioSource musicSource;
        [SerializeField] private AudioSource[] sfxSources;

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

        public void PlaySFX(AudioClip sfxClip)
        {
            foreach (var sfxSource in sfxSources)
            {
                if (!sfxSource.isPlaying)
                {
                    sfxSource.clip = sfxClip;
                    sfxSource.Play();
                    return;
                }
            }
        }

        public void SetMusicVolume(float volume)
        {
            musicSource.volume = volume;
        }

        public void SetSFXVolume(float volume)
        {
            foreach (var sfxSource in sfxSources)
            {
                sfxSource.volume = volume;
            }
        }

        public float GetMusicVolume()
        {
            return musicSource.volume;
        }

        public float GetSFXVolume()
        {
            return sfxSources[0].volume;
        }

        public void MuteAllAudio(bool isMuted)
        {
            AudioListener.pause = isMuted;
        }
    }
}