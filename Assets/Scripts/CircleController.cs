using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CircleController : MonoBehaviour, IPointerClickHandler
{
    public TutorialController tutorialController;

    public void OnPointerClick(PointerEventData eventData)
    {
        // Cuando el usuario hace clic en el círculo, desactiva el círculo
        gameObject.SetActive(false);

        // Comprueba si todos los círculos están desactivados
        bool allCirclesDisabled = true;
        foreach (Transform child in transform.parent)
        {
            if (child.gameObject.activeSelf)
            {
                allCirclesDisabled = false;
                break;
            }
        }

        // Si todos los círculos están desactivados, notifica al controlador del tutorial que se ha completado un reto
        if (allCirclesDisabled)
        {
            tutorialController.CompleteChallenge();
        }
    }
}
