using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clon : MonoBehaviour
{
    public GameObject acorn;
    public Transform posRotAcorn;

    public float thrustY, thrustZ;

    private void Start()
    {
        //Invoke("CreateObjectsWithForce", 2);
        InvokeRepeating("CreateObjectsWithForce", 1, 2);

    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            CreateObjectsWithForce();
        }
    }

    private void CreateObjects()
    {
        // Creamos clones del prefab acorn
        // Como no le indico donde quiero que genere el clon,
        // me lo genera en la posición (0,0,0)
        Instantiate(acorn);
    }

    private void CreateObjectsWithPosition()
    {
        Instantiate(acorn, posRotAcorn.position, posRotAcorn.rotation);
    }


    private void CreateObjectsWithForce()
    {
        GameObject cloneAcorn = Instantiate(acorn, posRotAcorn.position, posRotAcorn.rotation);
        // El componente rigidbody con el que voy a trabajar es el de los
        // clones de la bellota
        Rigidbody rbAcorn = cloneAcorn.GetComponent<Rigidbody>();

        // Vector3.up hace referencia al eje Y global de la escena
        rbAcorn.AddForce(Vector3.up * thrustY);
        // transform.forward hace referecia al eje Z local, de posRor
        rbAcorn.AddForce(transform.forward * thrustZ);

        Destroy(cloneAcorn, 3);
        Invoke("Message", 4.5f);
    }

    void Message()
    {
        Debug.Log("Voy a ser un Jedi");
    }
}
