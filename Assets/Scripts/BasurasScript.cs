using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasurasScript : MonoBehaviour
{
    public void Eliminar(){
        Destroy(gameObject);
        //animator.SetTrigger("Muerte");
    }
}
