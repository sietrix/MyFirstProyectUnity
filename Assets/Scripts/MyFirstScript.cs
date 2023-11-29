using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFirstScript : MonoBehaviour
{
    public Vector3 posObject;
    public Vector3 scaleObject;
    public float xPos;

    // Variable de clase de tipo Light
    Light _light;
    private void Awake()
    {
        //Debug.Log("Awake");
        // Inicializo el componente Light
        _light = GetComponent<Light>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Start");
        _light.color = Color.red;
        _light.enabled = false;
        _light.range = 50; 


        xPos = transform.position.x;
        Debug.Log("La posición del objeto en X es: " + xPos);

        transform.position = posObject;
        Debug.Log("La posición del objeto es: " + transform.position);

        transform.localScale = scaleObject;


        // gameObject pertenece al GameObject que esté
        // vinculado este script
        //gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Update");
    }
}
