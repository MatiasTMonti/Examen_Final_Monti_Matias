using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEnemys : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Tank"))
        {
            Debug.Log("Colisión con el tanque detectada.");
            Destroy(other.gameObject);
        }
        else
        {
            Debug.Log("Colisión con otro objeto que no es el tanque.");
            Debug.Log("Tag del objeto colisionado: " + other.gameObject.tag);
        }
    }
}
