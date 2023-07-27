using UnityEngine;

namespace tankDefend
{
    public class TankCamera : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 offset = new Vector3(0f, 6f, -10f);
        [SerializeField] private float smoothSpeed = 0.125f;

        private void LateUpdate()
        {
            Vector3 desiredPosition = target.position + offset;

            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            transform.position = smoothedPosition;

            transform.LookAt(target);
        }
    }
}