using UnityEngine;

namespace tankDefend
{
    public class Bullet : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Terrain"))
            {
                Destroy(gameObject);
            }
        }
    }
}