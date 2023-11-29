using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyAttack : MonoBehaviour
{
    public Collider colliderAttack; // hace referencia al collider que lleva la espada
    private Animator anim;
    private Rigidbody rb;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // si pulso el bot�n izquierdo del rat�n
        {
            Attack();
        }
    }

    void Attack()
    {
        float v = Input.GetAxis("Vertical");
        if (v == 0)
        {
            // Ejecuto la animacion de ataque
            anim.SetTrigger("Attack");
        }
    }

    // Eventos en la animaci�n
    void EnableCollider()
    {
        // habilitando el componente para que el collider act�e en la escena
        colliderAttack.enabled = true;
    }

    void DesableCollider()
    {
        // deshabilitando el componente para que el collider act�e en la escena
        colliderAttack.enabled = false;
    }



}
