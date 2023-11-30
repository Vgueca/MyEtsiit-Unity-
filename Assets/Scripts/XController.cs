using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class XController : MonoBehaviour, IPointerEnterHandler
{
    public TutorialController tutorialController;

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Cuando el cursor entra en la X, desactiva la X
        gameObject.SetActive(false);

        // Comprueba si todas las X están desactivadas
        bool allXsDisabled = true;
        foreach (Transform child in transform.parent)
        {
            if (child.gameObject.activeSelf)
            {
                allXsDisabled = false;
                break;
            }
        }

        // Si todas las X están desactivadas, notifica al controlador del tutorial que se ha completado un reto
        if (allXsDisabled)
        {
            tutorialController.CompleteChallenge();
        }
    }
}