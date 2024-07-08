using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoJefeHabilidad : MonoBehaviour
{
    [SerializeField] private int dañoAtaque;
    [SerializeField] private Vector2 dimensionesCaja;
    [SerializeField] private Transform posicioncaja;
    [SerializeField] private float tiempoDeVida;

    void Start()
    {
        Destroy(gameObject, tiempoDeVida);
    }

    public void Golpe()
    {
        Collider2D[] objetos = Physics2D.OverlapBoxAll(posicioncaja.position, dimensionesCaja, 0f);
        foreach(Collider2D collider in objetos){
            if(collider.CompareTag("Player")){
                collider.GetComponent<PersonajeVidaScript>().TomarDanio(dañoAtaque);
            }
        }
    }
    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(posicioncaja.position,dimensionesCaja);
    }
}
