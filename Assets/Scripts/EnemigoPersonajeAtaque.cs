using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoPersonajeAtaque : MonoBehaviour
{
    [SerializeField] private Vector2 velocidadRebote;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            other.gameObject.GetComponent<PersonajeVidaScript>().TomarDanio(1,velocidadRebote);
        }
    }
}
