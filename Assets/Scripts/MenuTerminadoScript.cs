using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MenuTerminadoScript : MonoBehaviour
{
    [SerializeField] private GameObject MenuTerminado;
    private EnemigoJefe jefe;
    private void Start() {
        jefe = GameObject.Find("Jefe").GetComponent<EnemigoJefe>();
        jefe.MuerteJefe += ActivarMenu;
        
    }

    private void ActivarMenu(object sender, EventArgs e)
    {
        MenuTerminado.SetActive(true);
        PlayerPrefs.SetFloat("PuntajeTotal", PlayerPrefs.GetFloat("PuntajeTotal")+PlayerPrefs.GetFloat("PuntajeEscena"));
        PlayerPrefs.SetFloat("PuntajeEscena",0);
        //Time.timeScale = 0;
    }

    public void Reiniciar(){
        Time.timeScale = 1;
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Jugador"),LayerMask.NameToLayer("Enemigos"),false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MenuInicial(string nombre){
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Jugador"),LayerMask.NameToLayer("Enemigos"),false);
        SceneManager.LoadScene(nombre);
    }
}
