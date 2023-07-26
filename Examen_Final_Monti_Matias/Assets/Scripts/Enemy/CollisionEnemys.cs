using UnityEngine;

namespace tankDefend
{
    public class CollisionEnemys : MonoBehaviour
    {
        [SerializeField] private DestroySphereCount destroySphereCount;

        private void OnTriggerEnter(Collider other)
        {
            if (gameObject != null)
            {
                if (other.gameObject.CompareTag("Tank"))
                {
                    Destroy(other.gameObject);
                }

                if (other.gameObject.CompareTag("Bullet"))
                {
                    ParticleManager.instance.PlayParticleDestroySphere(transform.position);
                    destroySphereCount.IncrementSpheresDestroyed();
                    Destroy(gameObject);
                }
            }
        }
    }
}