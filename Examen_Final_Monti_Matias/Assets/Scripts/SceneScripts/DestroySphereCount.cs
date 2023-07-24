using UnityEngine;
using TMPro;

public class DestroySphereCount : MonoBehaviour
{
    [SerializeField] private int spheresDestroyed = 0;
    [SerializeField] private TextMeshProUGUI counterText;

    private void Start()
    {
        UpdateCounterText();
    }

    public void IncrementSpheresDestroyed()
    {
        spheresDestroyed++;
        UpdateCounterText();
    }

    public int GetSpheresDestroyed()
    {
        return spheresDestroyed;

    }

    private void UpdateCounterText()
    {
        counterText.text = "Spheres Destroyed: " + spheresDestroyed;
    }
}
