using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ControladorEnemigosScript : MonoBehaviour
{
    private float minX, maxX, minY, maxY;
    [SerializeField] private Transform[] puntos;
    [SerializeField] private GameObject[] enemigos;
    [SerializeField] private float tiempoEnemigos;
    private float tiempoSiguienteEnemigo; 
    [SerializeField] private float tiempo;
    private float tiempoCambio;
    private bool enemigo= true;
    // Start is called before the first frame update
    void Start()
    {
        maxX =puntos.Max(punto => punto.position.x);
        maxY =puntos.Max(punto => punto.position.y);
        minX =puntos.Min(punto => punto.position.x);
        minY =puntos.Min(punto => punto.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemigo){
            tiempoSiguienteEnemigo += Time.deltaTime;
            if (tiempoSiguienteEnemigo >= tiempoEnemigos){
                tiempoSiguienteEnemigo =0;
                CrearEnemigo();
            }
            tiempoCambio += Time.deltaTime;
            if(tiempoCambio >= tiempo){
                enemigo=false;
            }
        }
    }

    private void CrearEnemigo()
    {
        int numeroEnemigo = Random.Range(0, enemigos.Length);
        Vector2 posicionAleatorio = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        Instantiate(enemigos[numeroEnemigo], posicionAleatorio, Quaternion.identity);
    }
}
