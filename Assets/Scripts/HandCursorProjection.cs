using System.Collections;
using System.Collections.Generic;
using Leap;
using Leap.Unity;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class HandCursorProjection : MonoBehaviour
{
    public LeapProvider leapProvider;

    public Texture2D cursorTexture;


    private bool canClick = true;

    private void OnEnable()
    {
        // Suscribirse al evento de actualización de la mano
        leapProvider.OnUpdateFrame += OnUpdateFrame;
    }

    private void OnDisable()
    {
        // Desuscribirse del evento de actualización de la mano
        leapProvider.OnUpdateFrame -= OnUpdateFrame;
    }

    void OnUpdateFrame(Frame frame)
    {   
        // Obtener la mano derecha
        Hand _righthand = frame.GetHand(Chirality.Right);

        if(_righthand != null)
        {
        
            // Obtenemos la posicion de la palma derecha en la pantalla
            Vector2 handScreenPos = handtoScreen(_righthand);
            
            // Mover el cursor a la posición de la mano de la mano proyectada en la pantalla
            MoveCursor(handScreenPos);

            // Comprobar si la mano está cerrada
            if(IsHandClosed(_righthand) && canClick)
            {
                // Simular un clic del ratón
                SimulateLeftClick();

                // Desactivar los clics durante un corto período de tiempo
                canClick = false;
                Invoke("EnableClick", 0.5f); // 0.5 segundos de retraso
            }
        }


    }



    void EnableClick()
    {
        canClick = true;
    }

    //con esta función actualizamos la posición del cursor
    public Vector2 handtoScreen(Hand hand)
    {
        // Obtener la posición de la mano
        Vector3 handWorldPos = hand.PalmPosition;

        // Actualizar la posición del cursor
        // Convertir la posición de la mano en coordenadas de la pantalla
        Vector2 handScreenPos = Camera.main.WorldToScreenPoint(handWorldPos);

        return handScreenPos;
        
    }




    public void MoveCursor(Vector2 position)
    {
        // Mover el cursor a la posición especificada
        Mouse.current.WarpCursorPosition(position);
        
    }


    //con esta función simulamos un click izquierdo
    public void SimulateLeftClick()
    {
        // Crear un nuevo estado de ratón con el botón izquierdo presionado
        Mouse.current.CopyState<MouseState>(out var mouseState);

        mouseState = mouseState.WithButton(MouseButton.Left, true);

        // Enviar el evento de presión del botón
        InputSystem.QueueStateEvent(Mouse.current, mouseState);

        // Crear un nuevo estado de ratón con el botón izquierdo liberado
        mouseState = mouseState.WithButton(MouseButton.Left, false);

        // Enviar el evento de liberación del botón
        InputSystem.QueueStateEvent(Mouse.current, mouseState);

        Debug.Log("Has hecho click izquierdo");
    }
    




    
    //funcion que comprueba que la mano esta cerrada
    bool IsHandClosed(Hand hand)
    {
    // Comprobar si todos los dedos están extendidos
    bool allFingersExtended = true;
    foreach (Finger finger in hand.Fingers)
    {
        if (!finger.IsExtended)
        {
            allFingersExtended = false;
            break;
        }
    }

    // Si todos los dedos están extendidos, la mano está abierta
    // Si no, la mano está cerrada
    return !allFingersExtended;
}
}
