using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    public GameObject specificImage;
    public GameObject specificButton;

    public void OnButtonClick()
    {
        // Deshabilitar todas las imágenes y botones específicos
        DisableAll();

        // Habilitar la imagen y el botón específicos
        specificImage.SetActive(true);
        specificButton.SetActive(true);
    }

    private void DisableAll()
    {
        
    }
}