using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoScript : MonoBehaviour
{
    [SerializeField] private float vida;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TomarDanio(float danioGolpe){
        vida -=danioGolpe;
        if(vida <= 0){
            Muerte();
        }
    }
    private void Muerte(){
        bool existe=false;
        foreach (AnimatorControllerParameter param in animator.parameters)
        {
            if (param.name == "Muerte")
            {
                existe=true;
                break;
            }
        }
        if(existe){
            animator.SetTrigger("Muerte");
        }else{
            Destruir();
        }
    }
    
    public void Destruir() =>Destroy(gameObject);
    /*private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player")) {
            Debug.Log("Veces");
            other.gameObject.GetComponent<PersonajeVidaScript>().TomarDanio(1,other.GetContact(0).normal);
        }
    }*/
}
