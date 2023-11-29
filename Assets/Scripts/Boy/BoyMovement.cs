using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyMovement : MonoBehaviour
{
    [Header("Movement")]
    public int speed, turnSpeed;

    [Header("Raycast")]
    public float rayLength; // longitud del ray
    public LayerMask rayLayer; // la capa de objetos que va a detectar el raycast

    [Header("Jump")]
    public float jumpForce;


    private float horizontal, vertical;
    private Animator anim;
    private Ray ray;
    private RaycastHit hit;
    private bool isGrounded; // esta variable me va a decir si el personaje está tocando el suelo o no
    private bool canPlayerJump;
    private Rigidbody rb;



    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        InputPlayer();
        Move();
        Rotate();
        Animating();
        CanJump(); // gestiona si el player va a saltar
    }

    private void FixedUpdate()
    {
        LauchRaycast(); // gestiona si el player está tocando el suelo
        Jump();
    }

    void LauchRaycast()
    {
        ray.origin = transform.position; // el punto de pivote
        ray.direction = -transform.up; // hacia abajo

        // Lanzo un raycast selectivo, que tiene una determinada longitud (rayLength),
        // y solo va a detectar los objetos de la capa rayLayer
        if (Physics.Raycast(ray, out hit, rayLength, rayLayer))
        {
            // puedo saltar:
            isGrounded = true;
            Debug.Log("Estoy tocando suelo");
        }
        else
        {
            isGrounded = false;
        }
        Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.red);
    }

    void CanJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            canPlayerJump = true;
        }
    }

    void Jump()
    {
        if (canPlayerJump)
        {
            // SALTO
            rb.AddForce(Vector3.up * jumpForce);
            canPlayerJump = false;
        }
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

    void Rotate()
    {
        transform.Rotate(Vector3.up * turnSpeed * horizontal * Time.deltaTime);
    }

    void Animating()
    {
        if (vertical != 0) // el personaje se está moviendo
        {
            anim.SetBool("IsMoving", true);
        }
        else
        {
            anim.SetBool("IsMoving", false);

        }

        // el personaje esta en el aire saltado 
        if (rb.velocity.y > 0)
        {
            anim.SetBool("IsJumping", true);
        }
        else
        {
            anim.SetBool("IsJumping", false);

        }
    }


}




