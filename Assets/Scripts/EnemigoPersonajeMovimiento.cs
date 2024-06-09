using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoPersonajeMovimiento : MonoBehaviour
{
    [Header("Movimiento")]
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
    public int rutina;
    public float cronometro;
    [Header("Detectar Personaje")]
    public Animator animator;
    public GameObject target;
    public bool atacar;
    public float rango_vision;
    public float rango_ataque;
    public float velocidadMovimientoAumentada;
    public GameObject rango;
    public GameObject Hit;
    public BoxCollider2D boxCollider2DIdle;
    public BoxCollider2D boxCollider2DAtacar;

    void Start()
    {
        animator = GetComponent<Animator>();
        target = GameObject.Find("Personaje1");
    }
    private void Update() {
        informacionEnFrente = Physics2D.Raycast(controladorEnFrente.position, transform.right, distanciaEnFrente, capaEnFrente);
        informacionAbajo = Physics2D.Raycast(controladorAbajo.position, transform.up * -1, distanciaAbajo, capaAbajo);

        Comportamiento();
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
    public void Comportamiento(){
        if(target == null || (Mathf.Abs(transform.position.x - target.transform.position.x) > rango_vision && !atacar)){
            // Caminar

            cronometro +=1 * Time.deltaTime;
            if(cronometro >= 4){
                rutina = Random.Range(0,2);
                cronometro = 0;
            }
            switch(rutina){
                case 0:
                    boxCollider2DIdle.enabled = true;
                    boxCollider2DAtacar.enabled = false;
                    animator.SetBool("Correr",false);
                    rigidbody.velocity *=0;
                    break;
                case 1:
                    rutina++;
                    break;
                default:
                    boxCollider2DIdle.enabled = true;
                    boxCollider2DAtacar.enabled = false;
                    rigidbody.velocity = new Vector2(velocidadMovimiento, rigidbody.velocity.y);
                    if(informacionEnFrente || !informacionAbajo) {
                        Girar();
                    }
                    animator.SetBool("Correr",true);
                    break;
            }
        } else {
            // Personaje Detectado
            if(Mathf.Abs(transform.position.x - target.transform.position.x) > rango_ataque && !atacar){
                // Correr hacia el personaje - derecha o izquierda
                if(transform.position.x < target.transform.position.x){
                    animator.SetBool("Correr",true);
                    transform.Translate(Vector3.right * velocidadMovimientoAumentada * Time.deltaTime);
                    transform.rotation = Quaternion.Euler(0,0,0);
                    animator.SetBool("Atacar",false);
                }else{
                    animator.SetBool("Correr",true);
                    transform.Translate(Vector3.right* velocidadMovimientoAumentada*Time.deltaTime);
                    transform.rotation= Quaternion.Euler(0,180,0);
                    animator.SetBool("Atacar",false);
                }
            }else{
                // Rango del ataque
                if(!atacar){
                    if(transform.position.x < target.transform.position.x){
                        transform.rotation = Quaternion.Euler(0,0,0);
                    }else{
                        transform.rotation = Quaternion.Euler(0,180,0);
                    }
                    animator.SetBool("Correr",false);
                }
            }
        }
    }

    public void Final_Animacion(){
        animator.SetBool("Atacar",false);
        atacar = false;
        rango.GetComponent<BoxCollider2D>().enabled = true;
    }
    public void ColliderWeaponTrue() 
        => Hit.GetComponent<BoxCollider2D>().enabled = true;
    public void ColliderWeaponFalse() 
        => Hit.GetComponent<BoxCollider2D>().enabled = false;
}
