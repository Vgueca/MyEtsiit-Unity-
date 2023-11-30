using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialController : MonoBehaviour
{
    public TextMeshProUGUI  instructionText; // El texto de las instrucciones
    public GameObject[] challenges; // Los retos del tutorial
    private int currentChallenge = 0; // El reto actual

    void Start()
    {
        // Al iniciar el juego, muestra el primer reto
        ShowChallenge(currentChallenge);
    }

    public void CompleteChallenge()
    {
        // Cuando se completa un reto, pasa al siguiente
        currentChallenge++;
        if (currentChallenge < challenges.Length)
        {
            ShowChallenge(currentChallenge);
        }
        else
        {
            instructionText.text = "¡Has completado el tutorial!";
        }
    }


    //Muestra el challenge
    private void ShowChallenge(int challengeIndex)
    {
        // Oculta todos los retos
        foreach (GameObject challenge in challenges)
        {
            challenge.SetActive(false);
        }

        // Muestra el reto actual
        challenges[challengeIndex].SetActive(true);

        // Actualiza el texto de las instrucciones
        switch (challengeIndex)
        {
            case 0:
                instructionText.text = "Mueve el cursor hacia las estrellas.";
                break;
            case 1:
                instructionText.text = "Haz clic en los globos.";
                break;
            // Añade más casos según sea necesario
        }
    }
}
