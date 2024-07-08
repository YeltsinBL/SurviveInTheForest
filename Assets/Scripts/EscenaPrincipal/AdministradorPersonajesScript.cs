using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdministradorPersonajesScript : MonoBehaviour
{
    // Se aplica el patrón de diseño singelton para llamar y mover los personajes entre escenas
    public static AdministradorPersonajesScript Instance;
    public List<Personajes> personajes; // Lista de todo los personajes agregados

    private void Awake() {
        /**
        Verificamos si la instancia del objeto no existe en la escena,
        hacemos que la haga igual así misma; o sino que la destruya.
        DontDestroyOnLoad: para pasarlo entre escena, solo se ejecuta si esta en la jerarquía principal
        **/
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }else Destroy(gameObject);
    }
}
