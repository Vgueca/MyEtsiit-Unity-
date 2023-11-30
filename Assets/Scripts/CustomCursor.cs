using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    public Texture2D normalCursorTexture;

    public Texture2D clickCursorTexture;

    // Start is called before the first frame update
    public void Start()
    {
        Cursor.SetCursor(normalCursorTexture, Vector2.zero, CursorMode.ForceSoftware);
    }

    // Update is called once per frame
    public void Update()
    {
        // Comprobar si se está presionando el botón izquierdo del ratón
        if (Input.GetMouseButtonDown(0))
        {
            // Cambiar a la textura de clic
            Debug.Log("Click");
            Cursor.SetCursor(clickCursorTexture, Vector2.zero, CursorMode.ForceSoftware);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // Cambiar de nuevo a la textura normal
            Cursor.SetCursor(normalCursorTexture, Vector2.zero, CursorMode.ForceSoftware);
        }
    }

}