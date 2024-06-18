using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoMovimientoPlataformaScript : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private Transform controladorSuelo;
    [SerializeField] private float distancia;
    [SerializeField] private Transform controladorPared;
    [SerializeField] private float distanciaPared;
    [SerializeField] private bool movimientoDerecha;
    public LayerMask capaEnFrente;
    private Rigidbody2D rb;
    private bool informacionPared;

    private void Start() {
        rb= GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        bool informacionSuelo = Physics2D.Raycast(controladorSuelo.position, Vector2.down, distancia);
        informacionPared = Physics2D.Raycast(controladorPared.position, 
        transform.right, distanciaPared,capaEnFrente);
        
        rb.velocity = new Vector2(velocidad, rb.velocity.y);
        if(informacionPared || informacionSuelo ==false ){
            Girar();
        }
    }

    private void Girar()
    {
        movimientoDerecha =!movimientoDerecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180,0);
        velocidad *=-1;
    }
    private void OnDrawGizmos() {
        Gizmos.color =Color.red;
        Gizmos.DrawLine(controladorSuelo.transform.position, controladorSuelo.transform.position + Vector3.down * distancia);
        Gizmos.DrawLine(controladorPared.transform.position, controladorPared.transform.position + controladorPared.transform.right * distanciaPared );

    }
}
