using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AdministradorCargaScript : MonoBehaviour
{
    [SerializeField]private int indexEscena=1;
    public Slider progressBar; // Referencia al slider de progreso

    private void Start()
    {
        // Inicia la coroutine para cargar la escena asíncronamente
        StartCoroutine(LoadAsyncScene(indexEscena));
    }
    /// <summary>
    /// Carga la barra de progreso para cambiar de escena
    /// </summary>
    /// <param name="nroEscena">Indice de la escena a mostrar</param>
    /// <returns></returns>
    IEnumerator LoadAsyncScene(int nroEscena)
    {
        // Inicia la carga asíncrona
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(nroEscena);
        // Desactivamos la escena
        asyncOperation.allowSceneActivation = false;

        // Mientras la escena está cargando, actualiza la barra de progreso
        while (!asyncOperation.isDone)
        {
            // La carga asíncrona está completa cuando llega a 0.9, por lo que normalizamos el progreso
            float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f);
            progressBar.value = progress;

            // Cuando la carga está completa, activa la escena
            if (asyncOperation.progress >= 0.9f)
            {
                asyncOperation.allowSceneActivation = true;
            }

            // Pausa la ejecución de la coroutine aquí, se reanudará en el siguiente frame
            yield return null;
        }
    }
}
