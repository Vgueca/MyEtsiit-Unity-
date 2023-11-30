using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RocketController : MonoBehaviour, IPointerClickHandler
{
    public TutorialController tutorialController;
    public float speed = 5f;
    private Vector2 direction;

    void Start()
    {
        // Al iniciar el juego, elige una dirección aleatoria para el cohete
        direction = Random.insideUnitCircle.normalized;
    }

    void Update()
    {
        // Mueve el cohete en la dirección elegida
        transform.Translate(direction * speed * Time.deltaTime);

        // Si el cohete llega al borde del Canvas, invierte su dirección
        if (!IsFullyVisibleFrom(Camera.main))
        {
            direction = -direction;
        }
    }



    public bool IsFullyVisibleFrom(Camera camera)
    {
        Vector3[] corners = new Vector3[4];
        GetComponent<RectTransform>().GetWorldCorners(corners);

        for (int i = 0; i < corners.Length; i++)
        {
            Vector3 viewportPos = camera.WorldToViewportPoint(corners[i]);
            if (viewportPos.x < 0 || viewportPos.x > 1 || viewportPos.y < 0 || viewportPos.y > 1)
            {
                return false;
            }
        }

        return true;
    }

    

    public void OnPointerClick(PointerEventData eventData)
    {
        // Cuando el usuario hace clic en el cohete, desactiva el cohete
        gameObject.SetActive(false);

        // Comprueba si todos los cohetes están desactivados
        bool allRocketsDisabled = true;
        foreach (Transform child in transform.parent)
        {
            if (child.gameObject.activeSelf)
            {
                allRocketsDisabled = false;
                break;
            }
        }

        // Si todos los cohetes están desactivados, notifica al controlador del tutorial que se ha completado un reto
        if (allRocketsDisabled)
        {
            tutorialController.CompleteChallenge();
        }
    }
}
