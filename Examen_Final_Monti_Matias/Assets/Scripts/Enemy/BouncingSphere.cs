using UnityEngine;

namespace tankDefend
{
    public class BouncingSphere : MonoBehaviour, IMovementStrategy
    {
        [SerializeField] private float bounceSpeed = 4f;
        [SerializeField] private float bounceHeight = 2f;

        public void Move(Transform transform, Vector3 targetPosition, float movementSpeed)
        {
            float yOffset = Mathf.Sin(Time.time * bounceSpeed) * bounceHeight;

            yOffset = Mathf.PingPong(yOffset, bounceHeight);

            Vector3 newPos = transform.position;
            newPos.y = yOffset;
            transform.position = newPos;
        }
    }
}