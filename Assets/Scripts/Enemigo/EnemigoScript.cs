using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemigoScript : MonoBehaviour
{
    [SerializeField] private float vida;
    [SerializeField] private Slider barravida;
    private Animator animator;
    private AdministradorAudioScript administradorAudioScript;
    // Start is called before the first frame update
    void Start()
    {
        administradorAudioScript = AdministradorAudioScript.Instance;
        animator = GetComponent<Animator>();
        
        if(barravida != null) {
            barravida.maxValue = vida;
            barravida.value = vida;
        }
    }
    private void Update() {
        if(vida <= 0){
            Muerte();
        }
    }

    public void TomarDanio(float danioGolpe){
        vida -=danioGolpe;
        if(barravida != null) barravida.value = vida;
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
    public void ReproducirEfecto(string nombre)
        => administradorAudioScript.PlayEfecto(nombre);
}
