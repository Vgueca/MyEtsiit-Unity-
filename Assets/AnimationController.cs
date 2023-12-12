using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAnimator : MonoBehaviour
{
    public Button weekButton; // El botón que muestra el día de la semana
    private Color originalColor; // El color original del botón

    void Start()
    {
        // Guarda el color original del botón
        originalColor = weekButton.image.color;
    }

    public void AnimateButton()
    {
        // Inicia la corutina de la animación
        StartCoroutine(AnimateButtonCoroutine());
    }

    IEnumerator AnimateButtonCoroutine()
    {
        // Cambia el color del botón a verde
        weekButton.image.color = Color.green;

        // Espera 0.5 segundos
        yield return new WaitForSeconds(0.5f);

        // Interpola el color del botón de vuelta al color original durante 0.5 segundos
        float elapsedTime = 0f;
        while (elapsedTime < 0.5f)
        {
            weekButton.image.color = Color.Lerp(Color.green, originalColor, elapsedTime / 0.5f);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Asegúrate de que el color del botón vuelve a ser el color original
        weekButton.image.color = originalColor;
    }
}
