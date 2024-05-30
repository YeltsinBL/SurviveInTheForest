using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoAvispa : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            other.GetComponent<PersonajeVidaScript>().TomarDanio(1);
        }
    }
}
