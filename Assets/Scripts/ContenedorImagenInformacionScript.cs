using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ContenedorImagenInformacionScript : MonoBehaviour
{
    public List<GameObject> listaDeImagenInformacion;
    public List<Sprite> listaDeResiduos;
    public GameObject contenedorImagenInformacionPrefab;
    public bool enemigo;

    private List<string> nombreEnemigo = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        VerificarListaVacia();
    }

    private void VerificarListaVacia()
    {
        if(!listaDeResiduos.Any()){
            GameObject[] buscar = GameObject.FindGameObjectsWithTag(enemigo?"Enemigo":"Basura");
            for(int i = 0; i < buscar.Count(); i++){    
                if(nombreEnemigo == null || !nombreEnemigo.Contains(buscar[i].name)){
                    nombreEnemigo.Insert(0,buscar[i].name);
                    listaDeResiduos.Add(buscar[i].GetComponent<SpriteRenderer>().sprite);
                }
            }
            CrearContenedorImagenInformacion();
        }
    }

    // Update is called once per frame
    void Update()
    {
        CrearContenedorImagenInformacion();
    }
    private void CrearContenedorImagenInformacion(){
        if(!listaDeImagenInformacion.Any()){
            for(int i = 0; i < listaDeResiduos.Count(); i++){
                GameObject contenedorImagenInformacion = Instantiate(contenedorImagenInformacionPrefab, transform);
                if (contenedorImagenInformacion.transform.childCount > 0)
                {
                    AsignarImagenInformacion(contenedorImagenInformacion, i);
                    AsignarCantidadInformacion(contenedorImagenInformacion, i);
                }
                listaDeImagenInformacion.Add(contenedorImagenInformacion);
            }
        }else{
            Debug.Log("Actualizar cantidad");
            for(int i = 0; i < listaDeImagenInformacion.Count(); i++){
                AsignarCantidadInformacion(listaDeImagenInformacion[i], i);
            }
        }
    }

    int CountGameObjectsWithName(string name)
    {
        GameObject[] allObjects = GameObject.FindGameObjectsWithTag(enemigo?"Enemigo":"Basura");
        int count = 0;

        foreach (GameObject obj in allObjects)
        {
            if (obj.name == name)
            {
                count++;
            }
        }
        return count;
    }
    private void AsignarImagenInformacion(GameObject contenedorImagenInformacion, int nroListaResiduo){
        Transform firstChildTransform = contenedorImagenInformacion.transform.GetChild(0);
        GameObject firstChildObject = firstChildTransform.gameObject;
        firstChildObject.GetComponent<Image>().sprite = listaDeResiduos[nroListaResiduo];
    }
    private void AsignarCantidadInformacion(GameObject contenedorImagenInformacion, int nroListaResiduo){
        Transform firstChildTransform = contenedorImagenInformacion.transform.GetChild(1).GetChild(0);
        GameObject firstChildObject = firstChildTransform.gameObject;
        firstChildObject.GetComponent<TextMeshProUGUI>().text =CountGameObjectsWithName(listaDeResiduos[nroListaResiduo].name).ToString("0");
    }

}
