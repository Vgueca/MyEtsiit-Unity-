using UnityEngine;
using UnityEngine.UI;
using Leap;
using Leap.Unity;
using System.Collections;

public class SwipeController : MonoBehaviour
{
    public GameObject[] days; // Array que contiene los objetos de los días
    public Button[] buttons; // Array que contiene los botones
    private int currentDay = 0; // Índice del día actual
    private Vector3 previousPalmPosition; // La posición de la palma de la mano derecha en el frame anterior
    public LeapServiceProvider provider; // El LeapServiceProvider


    void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int day = i;
            buttons[i].onClick.AddListener(() => 
            {
                currentDay = day;
                StartCoroutine(AnimateButton(buttons[currentDay]));
            });
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
                        // "Swipe" a la derecha: pasa al día siguiente
                        ChangeDay(-1);
                        StartCoroutine(AnimateButton(buttons[currentDay]));
                    }
                    else if (swipeDistance < -0.05) // Reducido a 0.1 para mayor sensibilidad
                    {
                        // "Swipe" a la izquierda: pasa al día anterior
                        ChangeDay(1);
                        StartCoroutine(AnimateButton(buttons[currentDay]));
                    }
                }

                previousPalmPosition = hand.PalmPosition;
            }
        }
    }

    void ChangeDay(int direction)
    {
        // Desactiva el día actual
        days[currentDay].SetActive(false);

        // Calcula el índice del nuevo día
        currentDay = (currentDay + direction) % days.Length;
        if (currentDay < 0) currentDay += days.Length;

        // Activa el nuevo día
        days[currentDay].SetActive(true);
    }

    IEnumerator AnimateButton(Button button)
    {
        // Guarda el tamaño y el color originales del botón
        Vector3 originalScale = button.transform.localScale;
        Color originalColor = button.image.color;

        // Aumenta el tamaño del botón y cambia su color a verde
        button.transform.localScale = originalScale * 1.2f;
        button.image.color = Color.green;

        // Espera 0.1 segundos
        yield return new WaitForSeconds(0.1f);

        // Reduce el tamaño del botón y cambia su color de vuelta al color original durante 0.1 segundos
        float elapsedTime = 0f;
        while (elapsedTime < 0.1f)
        {
            button.transform.localScale = Vector3.Lerp(button.transform.localScale, originalScale, elapsedTime / 0.1f);
            button.image.color = Color.Lerp(button.image.color, originalColor, elapsedTime / 0.1f);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Asegúrate de que el tamaño y el color del botón vuelven a ser los originales
        button.transform.localScale = originalScale;
        button.image.color = originalColor;
    }
}