using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWithForce : MonoBehaviour
{
    // Creamo la variable
    Rigidbody rb;

    public float thrust; // fuerza


    private void Awake()
    {
        // Inicializamos la variable
        // Indicandole qué rigidbody es el que vamos a utilizar
        rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        rb.AddForce(transform.up * thrust);
        rb.useGravity = true;
    }






}
