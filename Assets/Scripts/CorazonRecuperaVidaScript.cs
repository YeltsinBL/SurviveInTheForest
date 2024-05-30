using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorazonRecuperaVidaScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")) {
            other.gameObject.GetComponent<PersonajeVidaScript>().CurarVida(1);
            Destroy(gameObject);
        }
    }
}
