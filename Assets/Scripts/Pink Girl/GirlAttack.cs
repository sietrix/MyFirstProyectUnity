using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GirlAttack : MonoBehaviour
{
    // hace referencia al prefab de la pelota, NUNCA A UN OBJETO DE LA ESCENA
    public GameObject ballPrefab;
    public Transform posBall;

    public float thrustY, thrustZ;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CreateBall();
        }
    }

    private void CreateBall()
    {
        GameObject cloneBall = Instantiate(ballPrefab, posBall.position, posBall.rotation);
        // El componente rigidbody con el que voy a trabajar es el de los
        // clones de la bellota
        Rigidbody rbBall = cloneBall.GetComponent<Rigidbody>();

        // Vector3.up hace referencia al eje Y global de la escena
        rbBall.AddForce(Vector3.up * thrustY);
        // transform.forward hace referecia al eje Z local, de posRor
        rbBall.AddForce(transform.forward * thrustZ);

        //Invoke("Message", 4.5f);
        Destroy(cloneBall, 3);
    }

    /*void Message()
    {
        Debug.Log("Voy a ser un Jedi");
    }*/
}
