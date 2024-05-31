using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeUnoAtaqueScript : MonoBehaviour
{

    // Posición del controlador del golpe
    [SerializeField] private Transform controladorAtaque;
    // se hara la verificación de forma circular
    [SerializeField] private float radioGolpe; 
    // Daño que realiza
    [SerializeField] private float danioGolpe;
    [SerializeField] private float tiempoEntreAtaque;
    [SerializeField] private float tiempoSiguienteAtaque;
    private Animator animator;
    
    private void Start() {
        animator = GetComponent<Animator>();
    }
    private void Update() {
        if(tiempoSiguienteAtaque >0){
            tiempoSiguienteAtaque -= Time.deltaTime;
        }
        if(Input.GetButtonDown("Fire1") && tiempoSiguienteAtaque <=0){
            Golper();
            tiempoSiguienteAtaque = tiempoEntreAtaque;
        }
    }

    private void Golper(){
        animator.SetTrigger("Golpe");
        // Verificar lo que se toca al atacar
        Collider2D[] objetos= Physics2D.OverlapCircleAll(controladorAtaque.position, radioGolpe);
        foreach(Collider2D collider in objetos){
            if(collider.CompareTag("Enemigo")){
                collider.transform.GetComponent<EnemigoScript>().TomarDanio(danioGolpe);
            }
            if(collider.CompareTag("Basura")){
                collider.transform.GetComponent<BasurasScript>().Eliminar();
            }
        }
    }
    // Dibujar el circulo que será el área del golpe
    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorAtaque.position, radioGolpe);
    }
}
