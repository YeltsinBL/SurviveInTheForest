using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoMovimientoCaidaScript : MonoBehaviour
{
    public float caida=20;
    void Start()
    {
        Destroy(gameObject,10);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * caida * -transform.up;
    }
}
