using UnityEngine;

namespace tankDefend
{
    public class CollisionEnemys : MonoBehaviour
    {
        [SerializeField] private DestroySphereCount destroySphereCount;
        [SerializeField] private AudioSource impactBulletSFX;
        [SerializeField] private AudioSource impactSphereTankSFX;
        [SerializeField] private GameManager gameManager;

        private void OnTriggerEnter(Collider other)
        {
            if (gameObject != null)
            {
                if (other.gameObject.CompareTag("Tank"))
                {
                    impactSphereTankSFX.Play();
                    gameManager.OnGameOver.Invoke();
                    Destroy(other.gameObject);
                }

                if (other.gameObject.CompareTag("Bullet"))
                {
                    ParticleManager.instance.PlayParticleDestroySphere(transform.position);
                    destroySphereCount.IncrementSpheresDestroyed();
                    impactBulletSFX.Play();
                    Destroy(gameObject);
                }
            }
        }
    }
}