using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AdministradorNivelScript : MonoBehaviour
{
     [Header("Content Vieport")]
    public Image contentDisplay;
    public List<GameObject> contentPanels;

    [Header("Navigation Dots")]
    public GameObject dotsContainer;
    public GameObject dotPrefab;

    [Header("Pagination Buttons")]
    public Button nextButton;
    public Button prevButton;

    [Header("Page Settings")]
    public bool useTimer = false;
    public bool isLimitedSwipe = false;
    public float autoMoveTime = 5f;
    private float timer;
    public int currentIndex = 0;
    public float swipeThreshold = 50f;
    private Vector2 touchStartPos;

    // Reference to the RectTransform of the ScrollView
    public RectTransform contentArea;

    [Header("Desbloquear Nivel")]

    [SerializeField] private GameObject ImagenBloqueado;
    [SerializeField] private GameObject BotonJugar;
    //[SerializeField] private Button BotonJugar;

    void Start()
    {
        nextButton.onClick.AddListener(NextContent);
        prevButton.onClick.AddListener(PreviousContent);

        // Initialize dots
        InitializeDots();

        // Display initial content
        ShowContent();

        // Start auto-move timer if enabled
        if (useTimer)
        {
            timer = autoMoveTime;
            InvokeRepeating("AutoMoveContent", 1f, 1f); // Invoke every second to update the timer
        }
        //PlayerPrefs.SetInt("NivelesDesbloqueados",3);
        PlayerPrefs.SetInt("NivelesTotales",contentPanels.Count);
        EstadoNiveles();
    }
    void Update()
    {
        // Detect swipe input only within the content area
        DetectSwipe();
    }

# region ScrollView Escenas - Carrusel
    void InitializeDots()
    {
        // Create dots based on the number of content panels
        for (int i = 0; i < contentPanels.Count; i++)
        {
            GameObject dot = Instantiate(dotPrefab, dotsContainer.transform);
            Image dotImage = dot.GetComponent<Image>();
            dotImage.color = (i == currentIndex) ? Color.white : Color.gray;
            dotImage.fillAmount = 0f; // Initial fill amount
            // You may want to customize the dot appearance and layout here
        }
    }

    void UpdateDots()
    {
        // Update the appearance of dots based on the current index
        for (int i = 0; i < dotsContainer.transform.childCount; i++)
        {
            Image dotImage = dotsContainer.transform.GetChild(i).GetComponent<Image>();
            dotImage.color = (i == currentIndex) ? Color.white : Color.gray;

            float targetFillAmount = timer / autoMoveTime;
            StartCoroutine(SmoothFill(dotImage, targetFillAmount, 0.5f));
        }
    }

    IEnumerator SmoothFill(Image image, float targetFillAmount, float duration)
    {
        float startFillAmount = image.fillAmount;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            image.fillAmount = Mathf.Lerp(startFillAmount, targetFillAmount, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        image.fillAmount = targetFillAmount; // Ensure it reaches the exact target
    }

    void DetectSwipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchStartPos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Vector2 touchEndPos = Input.mousePosition;
            float swipeDistance = touchEndPos.x - touchStartPos.x;

            // Check if the swipe is within the content area bounds
            if (Mathf.Abs(swipeDistance) > swipeThreshold && IsTouchInContentArea(touchStartPos))
            {
                if (isLimitedSwipe && ((currentIndex == 0 && swipeDistance > 0) || (currentIndex == contentPanels.Count - 1 && swipeDistance < 0)))
                {
                    // Limited swipe is enabled, and at the edge of content
                    return;
                }

                if (swipeDistance > 0)
                {
                    PreviousContent();
                }
                else
                {
                    NextContent();
                }
            }
        }
    }

    // Check if the touch position is within the content area bounds
    bool IsTouchInContentArea(Vector2 touchPosition)
    {
        return RectTransformUtility.RectangleContainsScreenPoint(contentArea, touchPosition);
    }

    void AutoMoveContent()
    {
        timer -= 1f; // Decrease timer every second

        if (timer <= 0)
        {
            timer = autoMoveTime;
            NextContent();
        }

        UpdateDots(); // Update dots on every timer tick
    }

    void NextContent()
    {
        currentIndex = (currentIndex + 1) % contentPanels.Count;
        ShowContent();
        UpdateDots();
    }

    void PreviousContent()
    {
        currentIndex = (currentIndex - 1 + contentPanels.Count) % contentPanels.Count;
        ShowContent();
        UpdateDots();
    }

    void ShowContent()
    {
        // Activate the current panel and deactivate others
        for (int i = 0; i < contentPanels.Count; i++)
        {
            bool isActive = i == currentIndex;
            contentPanels[i].SetActive(isActive);

            // Update dot visibility and color based on the current active content
            Image dotImage = dotsContainer.transform.GetChild(i).GetComponent<Image>();
            dotImage.color = isActive ? Color.white : Color.gray;

            if (isActive)
            {
                // Reset timer and fill amount when the content is swiped
                timer = autoMoveTime;
                dotImage.fillAmount = 1f;
            }
            else
            {
                // Set the fill amount to 0 for non-active content
                dotImage.fillAmount = 0f;
            }
        }
        MostrarImagenBloqueado();
    }

    public void SetCurrentIndex(int newIndex)
    {
        if (newIndex >= 0 && newIndex < contentPanels.Count)
        {
            currentIndex = newIndex;
            ShowContent();
            UpdateDots();
        }
    }

# endregion

# region Desbloquear Niveles

/// <summary>
/// Activar los niveles que ya han sido desbloqueados o activar el primero por defecto
/// </summary>
    private void EstadoNiveles(){
        if(contentPanels.Count >0){
            if(PlayerPrefs.GetInt("NivelesDesbloqueados")==0) PlayerPrefs.SetInt("NivelesDesbloqueados",1);
            for (int i = 0; i < contentPanels.Count; i++)
                contentPanels[i].GetComponent<Image>().color = new Color32(123,105,105,244);
            
            for (int i = 0; i < PlayerPrefs.GetInt("NivelesDesbloqueados"); i++)
                contentPanels[i].GetComponent<Image>().color = new Color32(255,255,255,255);
            
        }
    }


/// <summary>
/// Mostrar el candado de bloqueado y ocultar el botón jugar
/// </summary>
    private void MostrarImagenBloqueado(){
        if (currentIndex+1 > PlayerPrefs.GetInt("NivelesDesbloqueados")){
            ImagenBloqueado.SetActive(true);
            BotonJugar.SetActive(false);
            //BotonJugar.interactable = false;
        }
        else {
            ImagenBloqueado.SetActive(false);
            BotonJugar.SetActive(true);
            //BotonJugar.interactable=true;
        }
        SeleccionarNivel();
    }
/// <summary>
/// 
/// </summary>
    private void SeleccionarNivel(){
        if(!ImagenBloqueado.activeSelf)
            PlayerPrefs.SetInt("EscenaIndex", currentIndex);
    }
# endregion

}
