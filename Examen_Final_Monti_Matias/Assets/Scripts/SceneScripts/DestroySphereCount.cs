using System.Collections;
using System.Collections.Generic;
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

    private void UpdateCounterText()
    {
        counterText.text = "Spheres Destroyed: " + spheresDestroyed;
    }
}
