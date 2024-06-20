using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoPersonajeAtaque : MonoBehaviour
{
    [SerializeField] private Vector2 velocidadRebote;
    [SerializeField] private int dañoRealizado;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            other.gameObject.GetComponent<PersonajeVidaScript>().TomarDanio(dañoRealizado,velocidadRebote);
        }
    }
}
