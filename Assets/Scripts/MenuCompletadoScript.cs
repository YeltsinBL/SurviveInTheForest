using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MenuCompletadoScript : MonoBehaviour
{
    [SerializeField] private GameObject MenuCompletado;
    private PuntoDeControlScript puntoDeControlScript;

    private void Start() {
        puntoDeControlScript = GameObject.FindGameObjectWithTag("PuntoDeControl").GetComponent<PuntoDeControlScript>();
        Debug.Log("puntoDeControlScript: "+ puntoDeControlScript);
        puntoDeControlScript.NivelCompletado += ActivarMenu;
    }

    private void ActivarMenu(object sender, EventArgs e)
    {
        Debug.Log("ActivarMenuCompletado");
        MenuCompletado.SetActive(true);
        Time.timeScale = 0;
    }

    public void Reiniciar(){
        Time.timeScale = 1;
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Jugador"),LayerMask.NameToLayer("Enemigos"),false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MenuInicial(string nombre){
        SceneManager.LoadScene(nombre);
    }
    public void ContinuarNivel(){
        Time.timeScale = 1;
        // detiene la ejecución del juego en unity
        Debug.Log("Nivel Siguiente");
    }
}
