using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemigoJefe : MonoBehaviour
{
    private Animator animator;
    public new Rigidbody2D rigidbody2D;
    public Transform jugador;
    private bool mirandoDerecha = false;
    public event EventHandler MuerteJefe;

    //[Header("Vida")]
    //[SerializeField] private float vida;
    //[SerializeField] private BarraDeVida barraVida;
    [Header("Ataque")]
    [SerializeField] private Transform controladorAtaque;
    [SerializeField] private float radioAtaque;
    [SerializeField] private int dañoAtaque;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        //barraVida.InicializarBarraVida(vida);
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    /*public void TomarDaño(float daño){
        vida -=daño;
        //barraVida.CambiarVidaActual(vida);
        if(vida <=0){
            animator.SetTrigger("Muerte");
            Muerte();
        }
    }*/

    //private void Muerte() => Destroy(gameObject);
    private void Update(){
        if(jugador != null){
        float distanciaJugador = Vector2.Distance(transform.position, jugador.position);
        animator.SetFloat("distanciaJugador", distanciaJugador);
        //Debug.Log("distanciaJugador"+ distanciaJugador);

        }
    }
    public void MirarJugador(){
        //Debug.Log("MirarJugador"+ jugador.position.x + "-"+transform.position.x  +"-"+ mirandoDerecha);
        if((jugador.position.x > transform.position.x && !mirandoDerecha) || (jugador.position.x < transform.position.x && mirandoDerecha)){
            mirandoDerecha =!mirandoDerecha;
            transform.eulerAngles = new Vector3(0,transform.eulerAngles.y +180,0);
        }
    }

    public void Atacar(){
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorAtaque.position, radioAtaque);
        foreach(Collider2D collider in objetos){
            if(collider.CompareTag("Player")){
                collider.GetComponent<PersonajeVidaScript>().TomarDanio(dañoAtaque);
            }
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorAtaque.position,radioAtaque);
    }

    public void MuerteJefeEvento()=>MuerteJefe?.Invoke(this, EventArgs.Empty);
}
