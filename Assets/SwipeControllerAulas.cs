using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;
using UnityEngine.UI;

public class SwipeControllerAulas : MonoBehaviour
{
    public Canvas[] canvases; // Array que contiene los objetos Canvas
    public UnityEngine.UI.Image[] images; // Array que contiene las imágenes
    public GameObject[] labels; // Array que contiene las etiquetas
    private int currentIndex = 2; // Índice del Canvas, imagen y etiqueta actual
    private Vector3 previousPalmPosition; // La posición de la palma de la mano derecha en el frame anterior
    public LeapServiceProvider provider; // El LeapServiceProvider

    void Start()
    {
        foreach (Canvas canvas in canvases)
        {
            Button[] buttons = canvas.GetComponentsInChildren<Button>();
            foreach (Button button in buttons)
            {
                button.onClick.AddListener(() => ChangeContent(button.name == "RightArrow" ? 1 : -1));
            }
        }
    }

    void Update()
    {
        Frame frame = provider.CurrentFrame;
        foreach (Hand hand in frame.Hands)
        {
            if (hand.IsRight)
            {
                if (previousPalmPosition != null)
                {
                    float swipeDistance = hand.PalmPosition.x - previousPalmPosition.x;

                    if (swipeDistance > 0.05) // Reducido a 0.1 para mayor sensibilidad
                    {
                        // "Swipe" a la derecha: pasa al siguiente contenido
                        ChangeContent(-1);
                    }
                    else if (swipeDistance < -0.05) // Reducido a 0.1 para mayor sensibilidad
                    {
                        // "Swipe" a la izquierda: pasa al contenido anterior
                        ChangeContent(1);
                    }
                }

                previousPalmPosition = hand.PalmPosition;
            }
        }
    }

    void ChangeContent(int direction)
    {
        // Desactiva el Canvas, la imagen y la etiqueta actuales
        canvases[currentIndex].gameObject.SetActive(false);
        images[currentIndex].gameObject.SetActive(false);
        labels[currentIndex].gameObject.SetActive(false);

        // Calcula el índice del nuevo contenido
        currentIndex = (currentIndex + direction) % canvases.Length;
        if (currentIndex < 0) currentIndex += canvases.Length;

        // Activa el nuevo Canvas, la imagen y la etiqueta
        canvases[currentIndex].gameObject.SetActive(true);
        images[currentIndex].gameObject.SetActive(true);
        labels[currentIndex].gameObject.SetActive(true);
    }
}
