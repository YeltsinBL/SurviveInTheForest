using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RecuentoScript : MonoBehaviour
{
    private float nroPuntos;
    private float nroEnemigos;
    private float nroResiduos;
    [SerializeField] private TextMeshProUGUI TextMeshPuntos;
    [SerializeField] private TextMeshProUGUI TextMeshEnemigos;
    [SerializeField] private TextMeshProUGUI TextMeshResiduos;
    private TextMeshProUGUI Puntos;
    private TextMeshProUGUI Enemigos;
    private TextMeshProUGUI Residuos;


    private void Start() {
        Puntos = TextMeshPuntos.GetComponent<TextMeshProUGUI>();
        Enemigos = TextMeshEnemigos.GetComponent<TextMeshProUGUI>();
        Residuos = TextMeshResiduos.GetComponent<TextMeshProUGUI>();
    }

    private void Update(){
        Puntos.text = nroPuntos.ToString("0");
        nroResiduos = GameObject.FindGameObjectsWithTag("Basura").Length;
        Residuos.text =nroResiduos.ToString("0");
        nroEnemigos = GameObject.FindGameObjectsWithTag("Enemigo").Length;
        Enemigos.text =nroEnemigos.ToString("0");
    }
    public void SumarPuntos(float puntosEntrada){
        nroPuntos +=puntosEntrada;
        Debug.Log("Recuento " + nroPuntos);
        PlayerPrefs.SetFloat("PuntajeEscena", nroPuntos);
    }
    public void RestarResiduos(){
        nroResiduos--;
    }
    public void RestarEnemigos(){
        nroEnemigos--;
    }

}
