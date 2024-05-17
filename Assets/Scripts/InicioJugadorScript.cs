using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicioJugadorScript : MonoBehaviour
{
    void Start()
    {
        int indexJugador = PlayerPrefs.GetInt("JugadorIndex");
        GameObject nuevoObject = Instantiate(AdministradorPersonajesScript.Instance.personajes[indexJugador].gameObject, transform.position, Quaternion.identity);
        nuevoObject.transform.localScale = new Vector3(4.6f, 6.3f, 0.1f);
    }

}
