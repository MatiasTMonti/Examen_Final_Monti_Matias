using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    [SerializeField] private Toggle muteToggle;

    void Start()
    {
        muteToggle.isOn = AudioListener.pause;
    }

    public void ToggleAudioMute()
    {
        AudioListener.pause = muteToggle.isOn;
    }
}
