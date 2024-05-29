using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class CorazonesUI : MonoBehaviour
{
    public List<Image> listaCorazones;
    public GameObject corazonPrefab;
    public PersonajeVidaScript personajeVidaScript;
    public int indexActual;
    public Sprite corazonLleno, corazonVacio;
    
    private void Start() {
        Debug.Log("CorazonesUI");
    }
    private void Awake() {
        Debug.Log("CorazonesUI Awake");
        personajeVidaScript.cambioVida.AddListener(CambiarCorazones);
    }

    public void CambiarCorazones(int vidaActual)
    {
        Debug.Log("Lista vacia: "+listaCorazones.Any());
        if(!listaCorazones.Any()) CrearCorazones(vidaActual);
        else CambiarVida(vidaActual);
    }
    private void CrearCorazones(int vidaMaxima)
    {
        Debug.Log("CorazonesUI Crear");
        for (int i = 0; i < vidaMaxima; i++)
        {
            GameObject corazon = Instantiate(corazonPrefab, transform);
            listaCorazones.Add(corazon.GetComponent<Image>());

        }
        indexActual = vidaMaxima -1;
    }

    private void CambiarVida(int vidaActual)
    {
        if(vidaActual <= indexActual) QuitarCorazon(vidaActual);
        else AgregarCorazon(vidaActual);
    }

    private void AgregarCorazon(int vidaActual)
    {
        for (int i = indexActual; i < vidaActual; i++)
        {
            indexActual = i;
            listaCorazones[indexActual].sprite = corazonLleno;
        }
    }

    private void QuitarCorazon(int vidaActual)
    {
        for (int i = indexActual; i >= vidaActual; i--)
        {
            indexActual = i;
            listaCorazones[indexActual].sprite = corazonVacio;
        }
    }
}
