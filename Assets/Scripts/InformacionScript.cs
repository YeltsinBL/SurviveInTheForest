using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformacionScript : MonoBehaviour
{
    [SerializeField] private GameObject botonInformacion;
    [SerializeField] private GameObject menuInformacion;

    public void Informacion(){
        Time.timeScale = 0;
        botonInformacion.SetActive(false);
        menuInformacion.SetActive(true);
    }
    public void Reanudar(){
        Time.timeScale = 1;
        botonInformacion.SetActive(true);
        menuInformacion.SetActive(false);
    }
}
