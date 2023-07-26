using System.Collections.Generic;
using UnityEngine;

namespace tankDefend
{
    public class AudioSourcesManager : MonoBehaviour
    {
        [SerializeField] private List<AudioSource> sources;
        private void Start()
        {
            SetSourcesVolume(PlayerPrefs.GetFloat("volume", 1f));
        }
        public void SetSourcesVolume(float volume)
        {
            for (int i = 0; i < sources.Count; i++)
            {
                sources[i].volume = volume;
            }
        }
    }
}