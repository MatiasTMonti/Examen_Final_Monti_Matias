using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public static ParticleManager instance;

    [SerializeField] private GameObject shootParticlePrefab;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void PlayParticleShoot(Vector3 position)
    {
        if (shootParticlePrefab != null)
        {
            Instantiate(shootParticlePrefab, position, Quaternion.identity);
        }
    }
}
