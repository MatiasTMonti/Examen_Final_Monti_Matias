using UnityEngine;
using TMPro;

public class DestroySphereCount : MonoBehaviour
{
    [SerializeField] private int spheresDestroyed = 0;
    [SerializeField] private int totalSpheresInGame = 1;
    [SerializeField] private TextMeshProUGUI counterText;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GetComponent<GameManager>();
        UpdateCounterText();
    }

    public void IncrementSpheresDestroyed()
    {
        spheresDestroyed++;
        UpdateCounterText();

        if (spheresDestroyed >= totalSpheresInGame)
        {
            gameManager.OnAllSpheresDestroyed.Invoke();
        }
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
