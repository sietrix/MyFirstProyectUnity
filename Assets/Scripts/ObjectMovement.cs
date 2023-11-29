using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public int speed;
    public int turnSpeed;

    private float horizontal,
                    vertical;
    void Start()
    {
        
    }

    void Update()
    {
        InputCube(); // comprobamos el estado de las teclas en cada frame

        /*
         * Vector3.forward = (0,0,1) -> VECTOR UNITARIO (dirección)
         * Vector3.right = (1,0,0)
         * Vector3.up = (0,1,0)
         */

        // Movimiento =  Dirección * Velocidad
        /*
         * Time.deltaTime es el tiempo entre updates y al multiplicar
         * pasa speed a metros por segundos
         */
     
        transform.Translate(Vector3.forward * vertical * speed * Time.deltaTime);
      

        transform.Rotate(Vector3.up * horizontal * turnSpeed * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Se ha pulsado la tecla P");
        }
    }

    // Decirle que teclas voy a usar (mapear las teclas)
    void InputCube()
    {
        // Teclas A y D y cruzeta de nuestro teclado (derecha y izquierda)
        horizontal = Input.GetAxis("Horizontal");
        // Teclas W y S y cruzeta de nuestro teclado (arriba y abajo)
        vertical = Input.GetAxis("Vertical");
    }

}
