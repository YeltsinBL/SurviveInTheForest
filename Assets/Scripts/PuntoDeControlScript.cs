using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PuntoDeControlScript : MonoBehaviour
{
    
    public event EventHandler NivelCompletado;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void NivelCompletadoEvento()=>NivelCompletado?.Invoke(this, EventArgs.Empty);
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            animator.SetTrigger("Activar");
        }
    }
}
