using UnityEngine;

public class MovementForTank : MonoBehaviour, IMovementStrategy
{
    public void Move(Transform transform, Vector3 targetPosition, float movementSpeed)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);
    }
}
