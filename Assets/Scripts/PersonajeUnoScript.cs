using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeUnoScript : MonoBehaviour
{
    private new Rigidbody2D rigidbody2D;
    private Animator animator;
    private float horizontal;// caminar
    public float speed; // velocidad
    public float jumpForce; // fuerza para saltar
    private bool grounded; // verifica si estamos en el suelo

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        // cambiar la mira del personaje (izquierda-derecha)
        if(horizontal < 0.0f) transform.localScale = new Vector3(-1,1,1.0f);
        else if(horizontal > 0.0f) transform.localScale = new Vector3(1,1,1.0f);

        // Activar la animación corriendo
        animator.SetBool("Running", horizontal !=0.0f);
        if(animator.GetBool("Running")){
            //gameObject.GetComponent<SpriteRenderer>().scale
            gameObject.transform.localScale = new Vector3(2.3f, 2.3f, 0.1f);
        }
        // Verificar si está en el suelo
        Debug.DrawRay(transform.position, Vector3.down * 0.09f, Color.red);
        if(Physics2D.Raycast(transform.position, Vector3.down, 0.09f)) grounded=true;
        else grounded=false;

        // agregar la tecla espacio para saltar
        if(Input.GetKeyDown(KeyCode.Space) && grounded) {
            Jump();
        } 
        if(!grounded) animator.SetBool("Jumping",true);
        else animator.SetBool("Jumping",false);

    }
    // Mover al personaje
    private void FixedUpdate() {
        rigidbody2D.velocity = new Vector2(horizontal * speed, rigidbody2D.velocity.y);
    }

    // Saltar
    private void Jump(){
        rigidbody2D.AddForce(Vector2.up * jumpForce);
    }
}
