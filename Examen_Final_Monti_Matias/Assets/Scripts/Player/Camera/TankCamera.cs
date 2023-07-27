using UnityEngine;

namespace tankDefend
{
    public class TankCamera : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 offset;
        [SerializeField] private float smoothSpeed = 0.125f;
        [SerializeField] private float mouseSensitivity = 2f;

        private Vector3 desiredPosition;
        private Vector3 smoothedPosition;

        private void LateUpdate()
        {
            if (target != null)
            {
                HandleMouseInput();
                desiredPosition = target.position + offset;
                smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
                transform.position = smoothedPosition;

                transform.LookAt(target);
            }
        }

        private void HandleMouseInput()
        {
            if (Input.GetMouseButton(1))
            {
                float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
                float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

                Vector3 newOffset = Quaternion.Euler(0f, mouseX, 0f) * offset;
                offset = Quaternion.Euler(-mouseY, 0f, 0f) * newOffset;
            }
        }
    }
}