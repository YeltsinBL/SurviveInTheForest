using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoRango2DScript : MonoBehaviour
{
    public Animator animator;
    public EnemigoPersonajeMovimiento enemigoPersonajeMovimiento;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            
            enemigoPersonajeMovimiento.boxCollider2DIdle.enabled = false;
            enemigoPersonajeMovimiento.boxCollider2DAtacar.enabled = true;
            animator.SetBool("Correr", false);
            animator.SetBool("Atacar", true);
            enemigoPersonajeMovimiento.atacar = true;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
