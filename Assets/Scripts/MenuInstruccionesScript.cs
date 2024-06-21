using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class MenuInstruccionesScript : MonoBehaviour
{
    public VideoScript[] videoScripts;
    public VideoPlayer videoPlayer;
    [SerializeField] private TextMeshProUGUI textoBotonSeleccionado;
    private TextMeshProUGUI textoBoton;

    void Start()
    {
        textoBoton = textoBotonSeleccionado.GetComponent<TextMeshProUGUI>();
    }
    public void EscogerVideo(string nombreAudio){
        VideoScript sonido = Array.Find(videoScripts, x=>x.Nombre == nombreAudio);
        if(sonido == null){
            Debug.Log("Video no encontrado");
        }else{
            Debug.Log("Video encontrado");
            videoPlayer.clip = sonido.clip;
            //videoPlayer.Play();
        }
    }
    public void BotonPresionado(string nombre) => textoBoton.text = nombre;
    
}
