using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AdministradorAudioScript : MonoBehaviour
{
    public SonidoScript[] sonidoMusica, sonidosEfecto;
    public AudioSource musicaSource, efectosSource;
    [SerializeField] private Slider sliderEfecto, sliderMusica;
    [SerializeField] private float valorSliderEfecto, valorSliderMusica;
    public static AdministradorAudioScript Instance;
    [SerializeField] private Button botonMusica, botonEfecto;
    [SerializeField] private TextMeshProUGUI textoBotonMusica, textoBotonEfecto;
    void Start()
    {
        sliderMusica.value = PlayerPrefs.GetFloat("VolumenMusica", valorSliderMusica);
        sliderEfecto.value = PlayerPrefs.GetFloat("VolumenEfecto", valorSliderEfecto);
        PlayMusica("exploration");
    }
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

# region Reproducir
/// <summary>
/// Reproduce la música de fondo
/// </summary>
/// <param name="nombre">Nombre de la música</param>
    public void PlayMusica(string nombre){
        SonidoScript sonido = Array.Find(sonidoMusica, x=>x.Nombre == nombre);
        if(sonido == null){
            Debug.Log("Musica no encontrada");
        }else{
            Debug.Log("Musica encontrada");
            musicaSource.clip = sonido.clip;
            musicaSource.Play();
        }
    }
/// <summary>
/// Reproduce los efectos
/// </summary>
/// <param name="nombre">Nombre del efecto</param>
    public void PlayEfecto(string nombre){
        SonidoScript sonido = Array.Find(sonidosEfecto, x=>x.Nombre == nombre);
        if(sonido == null){
            Debug.Log("Efecto no encontrado");
        }else {
            Debug.Log("Efecto encontrado");
            efectosSource.PlayOneShot(sonido.clip);
        }
    }

# endregion
# region Volumen
/// <summary>
/// Cambiar el volumen de la Música
/// </summary>
/// <param name="valor">Número del volumen a reproducir</param>
    public void VolumenMusica(float valor){
        valorSliderMusica= valor;
        PlayerPrefs.SetFloat("VolumenMusica", valorSliderMusica);
        musicaSource.volume = PlayerPrefs.GetFloat("VolumenMusica");
    }

/// <summary>
/// Cambiar el volumen de la Efecto
/// </summary>
/// <param name="valor">Número del volumen a reproducir</param>
    public void VolumenEfecto(float valor){
        valorSliderEfecto= valor;
        PlayerPrefs.SetFloat("VolumenEfecto", valorSliderEfecto);
        efectosSource.volume = PlayerPrefs.GetFloat("VolumenEfecto");
    }

# endregion
# region Mutear
/// <summary>
/// Mutear o desmutear música
/// </summary>
    public void MutearMusica() {
        musicaSource.mute = !musicaSource.mute;
        CambiarColorBotones(botonMusica, textoBotonMusica);
    }
/// <summary>
/// Mutear o desmutear efecto
/// </summary>
    public void MutearEfecto() {
        efectosSource.mute = !efectosSource.mute;
        CambiarColorBotones(botonEfecto, textoBotonEfecto);
    }
    private void CambiarColorBotones(Button button, TextMeshProUGUI text) {
        Color valorColor=button.GetComponent<Image>().color;
        button.GetComponent<Image>().color = valorColor==Color.red?Color.green:Color.red;
        text.text = text.text=="SI"?"NO":"SI";
    }
# endregion
}
