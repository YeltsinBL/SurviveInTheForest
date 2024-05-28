using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicioJugadorScript : MonoBehaviour
{
    void Start()
    {
        int indexJugador = PlayerPrefs.GetInt("JugadorIndex");
        GameObject nuevoObject = Instantiate(AdministradorPersonajesScript.Instance.personajes[indexJugador].gameObject, transform.position, Quaternion.identity);
        nuevoObject.transform.localScale = new Vector3(2.3f, 2.3f, 1);
        Debug.Log("EscenaSeleccionada: "+ PlayerPrefs.GetInt("EscenaIndex"));
    }

}
