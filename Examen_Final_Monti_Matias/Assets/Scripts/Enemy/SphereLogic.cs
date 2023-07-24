using UnityEngine;

namespace tankDefend
{
    public class SphereLogic : MonoBehaviour
    {
        private IMovementStrategy movementStrategy;

        [SerializeField] private MovementSphere movementSphere;

        [SerializeField] private GameObject tank;

        private void Start()
        {
            int random = Random.Range(0, 2);
            if (random == 0)
            {
                movementStrategy = new BouncingSphere();
            }
            else
            {
                movementStrategy = new MovementForTank();
            }

        }

        private void Update()
        {
            if (tank != null)
            {
                if (movementStrategy != null)
                    movementStrategy.Move(transform, tank.transform.position, movementSphere.velocity);
            }
        }
    }
}
