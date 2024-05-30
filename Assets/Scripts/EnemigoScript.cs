using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoScript : MonoBehaviour
{
    [SerializeField] private float vida;
    //private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TomarDanio(float danioGolpe){
        vida -=danioGolpe;
        if(vida <= 0){
            Muerte();
        }
    }
    private void Muerte(){
        Destroy(gameObject);
        //animator.SetTrigger("Muerte");
    }
}
