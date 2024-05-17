using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Para que aparezca Personajes como opción en el Unity
[CreateAssetMenu(fileName = "NuevoPersonaje", menuName = "Personaje")]
public class Personajes : ScriptableObject // es un contenedor de información
{
    // Parámetros a recibir por cada personaje agregado
    public GameObject gameObject; // el objeto del personaje
    public Sprite imagen;
    public string nombre;
}
