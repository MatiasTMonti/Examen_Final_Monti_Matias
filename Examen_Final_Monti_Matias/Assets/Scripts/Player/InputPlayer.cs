using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace tankDefend
{
    public class InputPlayer : MonoBehaviour
    {
        [SerializeField] private float movementVelocity = 5f;
        [SerializeField] private float rotationVelocity = 10f;
        [SerializeField] private Transform turret;

        [SerializeField] private float shootForce = 1000f;
        [SerializeField] private GameObject bulletPrefab;

        private GameObject actualBullet;

        private Vector3 destino;
        private bool disparar;

        private void Update()
        {
            if (gameObject != null)
            {
                MoveInput();
                RotationInput();

                RotateTurret();

                Shooting();
            }
        }

        private void MoveInput()
        {
            float movimientoVertical = Input.GetAxis("Vertical") * movementVelocity * Time.deltaTime;
            transform.Translate(Vector3.forward * movimientoVertical);
        }

        private void RotationInput()
        {
            float movimientoHorizontal = Input.GetAxis("Horizontal") * rotationVelocity * Time.deltaTime;
            transform.Rotate(Vector3.up * movimientoHorizontal);
        }

        private void RotateTurret()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    destino = hit.point;
                    disparar = true;
                    Quaternion lookRotation = Quaternion.LookRotation(new Vector3(destino.x - transform.position.x, 0f, destino.z - transform.position.z));
                    turret.rotation = Quaternion.Lerp(turret.rotation, lookRotation, Time.deltaTime * rotationVelocity);
                }
            }
        }

        private void Shooting()
        {
            if (disparar)
            {
                Quaternion lookRotation = Quaternion.LookRotation(new Vector3(destino.x - transform.position.x, 0f, destino.z - transform.position.z));
                turret.rotation = Quaternion.Lerp(turret.rotation, lookRotation, Time.deltaTime * rotationVelocity);

                if (Quaternion.Angle(turret.rotation, lookRotation) < 1f)
                {
                    disparar = false;
                    Shoot();
                    ParticleManager.instance.PlayParticleShoot(transform.position);
                }
            }
        }

        private void Shoot()
        {
            if (actualBullet == null)
            {
                actualBullet = Instantiate(bulletPrefab, turret.position, turret.rotation);
                Rigidbody rb = actualBullet.GetComponent<Rigidbody>();
                rb.AddForce(turret.forward * shootForce);
            }
        }
    }
}