using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastExample : MonoBehaviour
{
    public float rayLength;
    public LayerMask rayMask;

    private Ray ray; // donde vamos a guarda la info del rayo
    private RaycastHit hit; // aquí se guarda la información del choque entre raycast y objeto (collider)

    void Start()
    {
        
    }

    void Update()
    {
        ray.origin = transform.position;
        ray.direction = transform.forward; // hacia delante, hacia donde está mirando el personaje

        // lanzamos el rayo
        if(Physics.Raycast(ray, out hit, rayLength, rayMask))
        {
            Debug.Log("Estoy chocando con algo " + hit.collider.name);
            Debug.Log("Punto impacto: " + hit.point);
            Debug.Log("Distacia: " + hit.distance);
            hit.collider.GetComponent<Rigidbody>().AddForce(Vector3.up * 300);
        }

        Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.red);
    }
}
