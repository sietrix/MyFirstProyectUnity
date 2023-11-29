using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlMovement : MonoBehaviour
{
    public float speed, turnSpeed;

    private float horizontal, vertical;

    private Animator anim;

    void Start()
    {
        // la variamble anim apunta al componente Animator del GameObject que lleve este script
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        InputPlayer();
        Move();
        Turn();
        Animating();
    }

    void InputPlayer() 
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    void Move()
    {
        transform.Translate(Vector3.forward * speed * vertical * Time.deltaTime);
    }

    void Turn()
    {
        transform.Rotate(Vector3.up * turnSpeed * horizontal * Time.deltaTime);
    }

    void Animating()
    {
        if(vertical != 0) // el personaje se está moviendo
        {
            anim.SetBool("IsMoving", true);
        } else
        {
            anim.SetBool("IsMoving", false);
        }

    }

}
