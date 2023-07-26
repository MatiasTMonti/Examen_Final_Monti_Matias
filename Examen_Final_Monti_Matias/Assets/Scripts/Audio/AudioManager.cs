using UnityEngine;

namespace tankDefend
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioSource buttonSfx;

        private AudioUI uiAudio;
        private AudioSettings playerPrefs;
        private AudioSourcesManager sourcesManager;

        private void Awake()
        {
            uiAudio = GetComponent<AudioUI>();
            playerPrefs = GetComponent<AudioSettings>();
            sourcesManager = GetComponent<AudioSourcesManager>();
            uiAudio.OnChangeMuteToggle += playerPrefs.SetAudioSettings;
            playerPrefs.OnReturnAudioSettings += uiAudio.SetVolume;
            playerPrefs.OnSetAudioSettings += sourcesManager.SetSourcesVolume;
            playerPrefs.OnReturnAudioSettings += sourcesManager.SetSourcesVolume;
        }

        private void OnDestroy()
        {
            uiAudio.OnChangeMuteToggle -= playerPrefs.SetAudioSettings;
            playerPrefs.OnSetAudioSettings -= sourcesManager.SetSourcesVolume;
            playerPrefs.OnReturnAudioSettings -= uiAudio.SetVolume;
            playerPrefs.OnReturnAudioSettings -= sourcesManager.SetSourcesVolume;
        }
        public void PLayButtonSfx()
        {
            buttonSfx.Play();
        }
    }
}