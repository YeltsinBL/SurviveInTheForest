using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // para cambiar las escenas

public class MenuInicialScript : MonoBehaviour
{
    public void Jugar(){
        /**
            Se puede pasar el nombre de la escena o el número.
            En este caso vamos a indicar que al número de la escena actual se sumará uno
        **/
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Salir(){
        Debug.Log("Salir");
        Application.Quit(); // solo funciona cuando el juego esta creado
    }
}
