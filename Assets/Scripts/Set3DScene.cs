using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Set3DScene : MonoBehaviour
{
    public string sceneName; // nombre de la nueva escena
    public GameObject image1; 
    public GameObject image2; 

    public void OnButtonClick()
    {
        // Cambia de escena
        SceneManager.LoadScene(sceneName);

        // Habilita la primera imagen y deshabilita la segunda
        image1.SetActive(true);
        image2.SetActive(false);
    }
}
