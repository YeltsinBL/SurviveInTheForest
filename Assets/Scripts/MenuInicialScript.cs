using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // para cambiar las escenas

public class MenuInicialScript : MonoBehaviour
{
    private int index;
    [SerializeField] public SpriteRenderer img;
    [SerializeField] private TextMeshProUGUI nombre;
    [SerializeField] private Animator animatorPrefab;
    private AdministradorPersonajesScript administradorPersonajes;
    [SerializeField] private TextMeshProUGUI PuntajeGlobal;
    private TextMeshProUGUI textoPuntaje;

    private void Start() {
        // Para que mantenga la misma instancia del Script
        administradorPersonajes = AdministradorPersonajesScript.Instance;
        //Guardamos a información
        index = PlayerPrefs.GetInt("JugadorIndex");

        // Por si se ha borrado algun personaje, que escoja al primero
        if (index > administradorPersonajes.personajes.Count - 1) index =0;
        CambiarPersonajePantalla();
        
        textoPuntaje = PuntajeGlobal.GetComponent<TextMeshProUGUI>();
        textoPuntaje.text = PlayerPrefs.GetFloat("PuntajeTotal").ToString("0");
    }

    private void CambiarPersonajePantalla(){
        PlayerPrefs.SetInt("JugadorIndex", index);
        Personajes personajeSeleccioando= administradorPersonajes.personajes[index];
        nombre.text = personajeSeleccioando.nombre;
        animatorPrefab.runtimeAnimatorController= personajeSeleccioando.gameObject.GetComponent<Animator>().runtimeAnimatorController;
        img.sprite = personajeSeleccioando.imagen;
        if (personajeSeleccioando.gameObject.GetComponent<Animator>().runtimeAnimatorController == null)
            Debug.Log($"El prefab del {personajeSeleccioando.nombre} no tiene un componente Animator.");
            
    }

    # region Botones
    public void Jugar(){
        /**
            Se puede pasar el nombre de la escena o el número.
            En este caso vamos a indicar que al número de la escena actual se sumará dos
        **/
        SceneManager.LoadScene(PlayerPrefs.GetInt("EscenaIndex") + 2);
    }
    public void Salir(){
        Debug.Log("Salir");
        UnityEditor.EditorApplication.isPlaying=false;
        Application.Quit(); // solo funciona cuando el juego esta creado
    }

    public void SiguientePersonaje() {
        if(index == administradorPersonajes.personajes.Count-1) index =0;
        else index +=1;
        CambiarPersonajePantalla();
    }
    public void AnteriorPersonaje() {
        if(index == 0) index = administradorPersonajes.personajes.Count-1;
        else index -=1;
        CambiarPersonajePantalla();
    }
    #endregion
}
