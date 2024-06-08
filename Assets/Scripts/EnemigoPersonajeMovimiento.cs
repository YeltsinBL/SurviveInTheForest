using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoPersonajeMovimiento : MonoBehaviour
{
    public new Rigidbody2D rigidbody;
    public float velocidadMovimiento;
    public LayerMask capaAbajo;
    public LayerMask capaEnFrente;
    public float distanciaAbajo;
    public float distanciaEnFrente;
    public Transform controladorAbajo;
    public Transform controladorEnFrente;
    public bool informacionAbajo;
    public bool informacionEnFrente;
    public bool mirandoALaDerecha = true;

    private void Update() {
        rigidbody.velocity = new Vector2(velocidadMovimiento, rigidbody.velocity.y);

        informacionEnFrente = Physics2D.Raycast(controladorEnFrente.position, transform.right, distanciaEnFrente, capaEnFrente);
        informacionAbajo = Physics2D.Raycast(controladorAbajo.position, transform.up * -1, distanciaAbajo, capaAbajo);

        if(informacionEnFrente || !informacionAbajo) {
            Girar();
        }
    }
    private void Girar() {
        mirandoALaDerecha = !mirandoALaDerecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180,0);
        velocidadMovimiento *= -1;
    }
    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(controladorAbajo.transform.position, controladorAbajo.transform.position + transform.up * -1 * distanciaAbajo);
        Gizmos.DrawLine(controladorEnFrente.transform.position, controladorEnFrente.transform.position + transform.right * distanciaEnFrente);
    }
}
