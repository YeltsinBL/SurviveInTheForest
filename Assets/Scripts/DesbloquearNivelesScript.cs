using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DesbloquearNivelesScript : MonoBehaviour
{
    public static DesbloquearNivelesScript Instance;
    public int desbloquearNiveles;

    private void Awake() {
        /**
        Verificamos si la instancia del objeto no existe en la escena,
        hacemos que la haga igual así misma; o sino que la destruya.
        DontDestroyOnLoad: para pasarlo entre escena, solo se ejecuta si esta en la jerarquía principal
        **/
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }else Destroy(gameObject);
    }
/// <summary>
/// Desbloquear solo los niveles que no han sido activados
/// </summary>
    public void DesbloquearNiveles(){
        // Aumenta el valor de las escenas desbloqueadas, solo si la escena actual es mayor a la ya guardada
        if(desbloquearNiveles > PlayerPrefs.GetInt("NivelesDesbloqueados",1)){
            PlayerPrefs.SetInt("NivelesDesbloqueados", desbloquearNiveles);
        }
        PlayerPrefs.SetInt("EscenaIndex", desbloquearNiveles);
    }

    public void MenuPrincipal(){
        //DesbloquearNiveles();
        SceneManager.LoadScene(1);
    }
    public void CambiarEscena(){
        DesbloquearNiveles();
        SceneManager.LoadScene(PlayerPrefs.GetInt("EscenaIndex") + 2);
    }
}
