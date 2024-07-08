using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ControladorEnemigosScript : MonoBehaviour
{
    private float minX, maxX, minY, maxY;
    private float tiempoSiguienteEnemigo; 
    [Header("PrimerosEnemigos")]
    [SerializeField] private Transform[] puntos;
    [SerializeField] private GameObject[] enemigos;
    [SerializeField] private float tiempoEnemigos;
    [SerializeField] private float tiempo;
    private float tiempoCambio;
    private bool enemigo= true;
    [Header("ElementosCaidas")]
    [SerializeField] private Transform[] puntosCaida;
    [SerializeField] private GameObject[] enemigosCaida;
    [SerializeField] private float tiempoEnemigosCaida;
    [SerializeField] private float tiempoCaida;
    private float tiempoCambioCaida;
    private bool caidas= false;
    // Start is called before the first frame update
    [SerializeField] private GameObject jefe;
    [SerializeField] private GameObject Menus;
    private MenuTerminadoScript menuTerminado;
    void Start()
    {
        maxX =puntos.Max(punto => punto.position.x);
        maxY =puntos.Max(punto => punto.position.y);
        minX =puntos.Min(punto => punto.position.x);
        minY =puntos.Min(punto => punto.position.y);
        jefe = GameObject.Find("Jefe");
        menuTerminado = Menus.GetComponent<MenuTerminadoScript>();
        jefe.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemigo){
            ControlarReSpawn(tiempoEnemigos);
            tiempoCambio += Time.deltaTime;
            if(tiempoCambio >= tiempo){
                enemigo=false;
                caidas = true;
                maxX =puntosCaida.Max(punto => punto.position.x);
                maxY =puntosCaida.Max(punto => punto.position.y);
                minX =puntosCaida.Min(punto => punto.position.x);
                minY =puntosCaida.Min(punto => punto.position.y);
                tiempoSiguienteEnemigo =0;
                tiempoCambio=0;
            }
        }
        if (caidas){
            ControlarReSpawn(tiempoEnemigosCaida);
            Debug.Log("tiempoSiguienteEnemigo"+tiempoSiguienteEnemigo);
            tiempoCambioCaida += Time.deltaTime;
            Debug.Log(tiempoCambioCaida >= tiempoCaida);
            if(tiempoCambioCaida >= tiempoCaida){
                caidas = false;
                jefe.SetActive(true);
                if(menuTerminado != null) menuTerminado.enabled = true;

            }
        }
    }
    private void ControlarReSpawn(float tiempoSpawb){
        tiempoSiguienteEnemigo += Time.deltaTime;
        Debug.Log(tiempoSiguienteEnemigo >= tiempoSpawb);
            if (tiempoSiguienteEnemigo >= tiempoSpawb){
                tiempoSiguienteEnemigo =0;
                CrearEnemigo();
            }
    }

    private void CrearEnemigo()
    {
        if(enemigo){
        int numeroEnemigo = Random.Range(0, enemigos.Length);
        Vector2 posicionAleatorio = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        Instantiate(enemigos[numeroEnemigo], posicionAleatorio, Quaternion.identity);
        }
        if(caidas){
            Debug.Log("Crear Caida");
            int numeroEnemigo = Random.Range(0, enemigosCaida.Length);
            Vector2 posicionAleatorio = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            Instantiate(enemigosCaida[numeroEnemigo], posicionAleatorio, Quaternion.identity);
        }
    }

}
