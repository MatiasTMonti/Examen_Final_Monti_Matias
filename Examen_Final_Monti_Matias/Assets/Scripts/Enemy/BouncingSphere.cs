using UnityEngine;

public class BouncingSphere : MonoBehaviour, IMovementStrategy
{
    [SerializeField] private float bounceSpeed = 4f;
    [SerializeField] private float bounceHeight = 2f;

    public void Move(Transform transform, Vector3 targetPosition, float movementSpeed)
    {
        // Calcula el rebote usando una función senoidal (Mathf.Sin) en el eje Y.
        float yOffset = Mathf.Sin(Time.time * bounceSpeed) * bounceHeight;

        // Utiliza Mathf.PingPong para que la esfera rebote continuamente entre 0 y la altura máxima (bounceHeight).
        yOffset = Mathf.PingPong(yOffset, bounceHeight);

        Vector3 newPos = transform.position;
        newPos.y = yOffset;
        transform.position = newPos;
    }
}