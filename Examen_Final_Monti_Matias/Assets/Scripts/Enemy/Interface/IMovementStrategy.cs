using UnityEngine;

public interface IMovementStrategy
{
    void Move(Transform transform, Vector3 targetPosition, float movementSpeed);
}
