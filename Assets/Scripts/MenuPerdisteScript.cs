using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MenuPerdisteScript : MonoBehaviour
{
    [SerializeField] private GameObject MenuPerdiste;
    private PersonajeVidaScript personajeVidaScript;
    private void Start() {
        personajeVidaScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PersonajeVidaScript>();
        Debug.Log("personajeVidaScript: "+ personajeVidaScript);
        personajeVidaScript.MuerteJugador += ActivarMenu;
    }

    private void ActivarMenu(object sender, EventArgs e)
    {
        Debug.Log("ActivarMenuPerdiste");
        MenuPerdiste.SetActive(true);
    }

    public void Reiniciar(){
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Jugador"),LayerMask.NameToLayer("Enemigos"),false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MenuInicial(string nombre){
        SceneManager.LoadScene(nombre);
    }
    public void Salir(){
        // detiene la ejecución del juego en unity
        UnityEditor.EditorApplication.isPlaying=false;
        Application.Quit();
    }
}
