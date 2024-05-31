using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeUnoScript : MonoBehaviour
{
    private new Rigidbody2D rigidbody2D;
    private Animator animator;
    public bool sePuedeMover =true;
    [SerializeField] private Vector2 velocidadRebote;

    [Header("Saltos")]
    private float horizontal;// caminar
    public float speed; // velocidad
    public float jumpForce; // fuerza para saltar
    private bool grounded; // verifica si estamos en el suelo
    private bool mirandoDerecha;
    private bool salto=false;
    [SerializeField] private int saltosExtrasRestantes;
    [SerializeField] private int saltosExtras;

    [Header("Escalar")]
    private float vertical;// subir
    [SerializeField] private float velocidadEscalar;
    private BoxCollider2D boxCollider2D;
    private float gravedadInicial;
    private bool escalando;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        gravedadInicial = rigidbody2D.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        // cambiar la mira del personaje (izquierda-derecha)
        if(horizontal < 0.0f && !mirandoDerecha) Girar();
        else if(horizontal > 0.0f && mirandoDerecha) Girar();
        // Activar la animación corriendo
        animator.SetBool("Running", horizontal !=0.0f);

        // Verificar si está en el suelo
        Debug.DrawRay(transform.position, Vector3.down * 0.6f, Color.red);
        if(Physics2D.Raycast(transform.position, Vector3.down, 0.6f)) grounded=true;
        else grounded=false;

        if(grounded) saltosExtrasRestantes = saltosExtras;
        // agregar la tecla espacio para saltar
        if(Input.GetKeyDown(KeyCode.Space)) {
            salto=true;
            //Jump();
        } 
        if(!grounded) animator.SetBool("Jumping",true);
        else animator.SetBool("Jumping",false);

    }
    // Mover al personaje
    private void FixedUpdate() {
        rigidbody2D.velocity = new Vector2(horizontal * speed, rigidbody2D.velocity.y);
        if(sePuedeMover) Movimiento(salto);
        Escalar();
        salto = false;
    }

    private void Movimiento(bool salto)
    {
        if(salto){
            if(grounded){
                Jump();
            }else{
                if(salto && saltosExtrasRestantes>0){
                    Jump();
                    saltosExtrasRestantes -=1;
                }
            }
        }
    }

    // Saltar
    private void Jump(){
        rigidbody2D.AddForce(Vector2.up * jumpForce);
        salto=false;
    }
    
    private void Girar(){
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *=-1;
        transform.localScale = escala;
    }

    public void Rebote(Vector2 puntoGolpe){
        Debug.Log("rigidbody2D.velocity:" +rigidbody2D.velocity);
        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x+(-velocidadRebote.x*puntoGolpe.x),velocidadRebote.y);
        Debug.Log("rigidbody2D.velocity2:" +rigidbody2D.velocity);
    }

    // Escalar
    private void Escalar(){
        if((vertical !=0 || escalando) && boxCollider2D.IsTouchingLayers(LayerMask.GetMask("Escaleras"))){
            Vector2 velocidadSubida = new Vector2(rigidbody2D.velocity.x, vertical * velocidadEscalar);
            rigidbody2D.velocity = velocidadSubida;
            rigidbody2D.gravityScale=0;
            escalando = true;
        }else{
            rigidbody2D.gravityScale = gravedadInicial;
            escalando = false;
        }

        if(grounded){
            escalando = false;

        }
    }
}
