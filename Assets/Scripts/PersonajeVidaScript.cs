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

    public event EventHandler MuerteJugador;

    private void Start() {
        vidaActual = vidaMaxima;
        cambioVida.Invoke(vidaActual); // invocar este evento cada vez que la vida cambia
        Debug.Log("vidaMaxima: "+vidaMaxima);
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

        if(vidaActual <=0) {
            MuerteJugador?.Invoke(this, EventArgs.Empty);
            Destroy(gameObject);
            //UnityEditor.EditorApplication.isPlaying=false;
            //Application.Quit();
        }
    }
    public void CurarVida(int cantidadCuracion){
        int vidaTemporal = vidaActual + cantidadCuracion;
        if (vidaTemporal > vidaMaxima) vidaActual = vidaMaxima;
        else vidaActual = vidaTemporal;
        cambioVida.Invoke(vidaActual);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        // Chocar con el hongo
        EnemigoScript hongoEnemigo = other.collider.GetComponent<EnemigoScript>();
        if(hongoEnemigo != null) {
            TomarDanio(1);
        }
    }
}
