using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Material mat;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("He colisionado con " + collision.gameObject.name);
        // Voy a ver si estoy chocando contra el cubo
        if(collision.collider.CompareTag("Enemy"))
        {
            // Cambio el material del cubo
            // Accedo a su componente Renderer y a su propiedad material
            collision.gameObject.GetComponent<Renderer>().material = mat;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("He colisionado Trigger con " + other.gameObject.name);
        if(other.CompareTag("Enemy"))
        {
            // Es other.gameObject está haciendo referencia
            // en este caso al cubo
            Destroy(other.gameObject);
        }
    }
}
