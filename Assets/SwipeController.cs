using UnityEngine;
using UnityEngine.UI;
using Leap;
using Leap.Unity;
using System.Collections;

public class SwipeController : MonoBehaviour
{
    public GameObject[] days; // Array que contiene los objetos de los días
    public Button[] buttons; // Array que contiene los botones
    private int currentDay; // Índice del día actual
    private Vector3 previousPalmPosition; // La posición de la palma de la mano derecha en el frame anterior
    public LeapServiceProvider provider; // El LeapServiceProvider

    public GameObject[] labels; // Array que contiene los objetos de los labels
    void Start()
    {   
        // Desactiva todos los días y las etiquetas
        foreach (GameObject day in days)
        {
            day.SetActive(false);
        }
        foreach (GameObject label in labels)
        {
            label.SetActive(false);
        }
        // Obtiene el día de la semana actual 
        currentDay = (int)System.DateTime.Now.DayOfWeek;
        currentDay = currentDay == 0 ? 6 : currentDay - 1; 

        // Activa el día actual
        days[currentDay].SetActive(true);
        //labels[currentDay].SetActive(true);

        for (int i = 0; i < buttons.Length; i++)
        {
            int day = i;
            Button button = buttons[i];
            button.onClick.AddListener(() => 
            {
                currentDay = day;
                StartCoroutine(AnimateButton(button));
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

        // Restaura el tamaño y el color de todos los botones
        foreach (Button button in buttons)
        {
            button.transform.localScale = new Vector3(1, 1, 1);
            button.image.color = Color.white;
        }

        // Marca el botón actual
        buttons[currentDay].transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        buttons[currentDay].image.color = Color.green;
    }


    void ChangeDay(int direction)
    {
        // Desactiva el día actual
        days[currentDay].SetActive(false);
        labels[currentDay].SetActive(false);

        // Calcula el índice del nuevo día
        currentDay = (currentDay + direction) % days.Length;
        if (currentDay < 0) currentDay += days.Length;

        // Activa el nuevo día
        days[currentDay].SetActive(true);
        labels[currentDay].SetActive(true);
    }

    IEnumerator AnimateButton(Button button)
    {
        // Si el botón está marcado, omite la animación
        if (button.transform.localScale.x > 1)
        {
            yield break;
        }

        // Guarda el tamaño y el color originales del botón
        Vector3 originalScale = button.transform.localScale;
        Color originalColor = button.image.color;

        button.transform.localScale = originalScale * 1.2f;
        button.image.color = Color.green;

        yield return new WaitForSeconds(0.1f);

        // Restaura el tamaño y el color originales del botón
        float elapsedTime = 0f;
        while (elapsedTime < 0.1f)
        {
            button.transform.localScale = Vector3.Lerp(button.transform.localScale, originalScale, elapsedTime / 0.1f);
            button.image.color = Color.Lerp(button.image.color, originalColor, elapsedTime / 0.1f);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        button.transform.localScale = originalScale;
        button.image.color = originalColor;
    }

}