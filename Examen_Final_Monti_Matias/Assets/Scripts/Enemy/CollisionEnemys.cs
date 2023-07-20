using UnityEngine;

public class CollisionEnemys : MonoBehaviour
{
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
                Destroy(gameObject);
            }
        }
    }
}
