using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class PersonajeVidaScript : MonoBehaviour
{
    public int vidaActual, vidaMaxima;

    public UnityEvent<int> cambioVida;
    public int valorPrueba;

    private Animator animator;
    public event EventHandler MuerteJugador;
    private new Rigidbody2D rigidbody2D;

    private PersonajeUnoScript personajeUnoScript;
    [SerializeField] private float tiempoPerdidaControl;
    private void Start() {
        personajeUnoScript = GetComponent<PersonajeUnoScript>();

        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        vidaActual = vidaMaxima;
        cambioVida.Invoke(vidaActual); // invocar este evento cada vez que la vida cambia
    }
    /*private void Update() {
        if(Input.GetButtonDown("Fire1") ){
            TomarDanio(valorPrueba);
        }
        if(Input.GetButtonDown("Fire2") ){
            CurarVida(valorPrueba);
        }
    }*/
    
    public void TomarDanio(int cantidadDanio){
        int vidaTemporal = vidaActual-cantidadDanio;
        if (vidaTemporal <0) vidaActual=0;
        else vidaActual = vidaTemporal;

        cambioVida.Invoke(vidaActual);
        personajeUnoScript.ReproducirEfecto("perdervida");

        if(vidaActual <=0) {
            // Para que el personaje no se mueva después de morir
            rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
            animator.SetTrigger("Muerte");
            // Ignorar las colisiones
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Jugador"),LayerMask.NameToLayer("Enemigos"),true);
        }
    }
    public void TomarDanio(int danio, Vector2 posicion){
        //vidaActual -=danio;
        TomarDanio(danio);
        //animator.SetTrigger("Golpe");
        StartCoroutine(PerderControl());
        //Perder Control
        personajeUnoScript.Rebote(posicion);

    }
    private IEnumerator PerderControl(){
        personajeUnoScript.sePuedeMover = false;
        yield return new WaitForSeconds(tiempoPerdidaControl);
        personajeUnoScript.sePuedeMover = true;
    }
    public void CurarVida(int cantidadCuracion){
        int vidaTemporal = vidaActual + cantidadCuracion;
        if (vidaTemporal > vidaMaxima) vidaActual = vidaMaxima;
        else vidaActual = vidaTemporal;
        personajeUnoScript.ReproducirEfecto("recuperarvida");
        cambioVida.Invoke(vidaActual);
    }

    public void Destruir() =>Destroy(gameObject);
    public void MuerteJugadorEvento()=>MuerteJugador?.Invoke(this, EventArgs.Empty);
}
