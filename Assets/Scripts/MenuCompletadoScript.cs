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
        puntoDeControlScript.NivelCompletado += ActivarMenu;
    }

    private void ActivarMenu(object sender, EventArgs e)
    {
        MenuCompletado.SetActive(true);
        Time.timeScale = 0;
        DesbloquearNiveles(PlayerPrefs.GetInt("NivelesDesbloqueados") + 1);
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
/// <summary>
/// Desbloquear solo los niveles que no han sido activados
/// </summary>
    public void DesbloquearNiveles(int desbloquearNiveles){
        // Aumenta el valor de las escenas desbloqueadas, solo si la escena actual es mayor a la ya guardada
        if(desbloquearNiveles > PlayerPrefs.GetInt("NivelesDesbloqueados",1) &&  desbloquearNiveles<=PlayerPrefs.GetInt("NivelesTotales")){
            PlayerPrefs.SetInt("NivelesDesbloqueados", desbloquearNiveles);
        }
    }
}
