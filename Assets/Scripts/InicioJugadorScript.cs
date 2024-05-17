using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicioJugadorScript : MonoBehaviour
{
    void Start()
    {
        int indexJugador = PlayerPrefs.GetInt("JugadorIndex");
        Instantiate(AdministradorPersonajesScript.Instance.personajes[indexJugador].gameObject, transform.position, Quaternion.identity);
    }

}
