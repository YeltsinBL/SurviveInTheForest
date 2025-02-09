using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausaScript : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;
    private bool juegoPausado = false;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if(juegoPausado) Reanudar();
            else Pausa();
        }
    }
    public void Pausa(){
        juegoPausado = true;
        Time.timeScale = 0;
        botonPausa.SetActive(false);
        menuPausa.SetActive(true);
    }
    public void Reanudar(){
        juegoPausado = false;
        Time.timeScale = 1;
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);
    }
    public void Reiniciar(){
        Time.timeScale = 1;
        PlayerPrefs.SetFloat("PuntajeEscena", 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MenuInicial(string nombre){
        PlayerPrefs.SetFloat("PuntajeEscena", 0);
        SceneManager.LoadScene(nombre);
    }
}
