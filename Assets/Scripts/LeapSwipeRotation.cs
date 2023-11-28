using System.Collections;
using System.Collections.Generic;
using Leap;
using Leap.Unity;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class LeapSwipeRotation: MonoBehaviour
{
    public LeapProvider leapProvider;
    private Vector3 initialObjectRotation;

    void Start()
    {
        initialObjectRotation = transform.rotation.eulerAngles;
    }
    
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
        Hand hand = frame.GetHand(Chirality.Right);
	
        if (hand == null)
	{
	    hand = frame.GetHand(Chirality.Left);
	}

	if(hand != null)
        {
            Vector3 palmVelocity = new Vector3(hand.PalmVelocity.x,hand.PalmVelocity.y,hand.PalmVelocity.z);

            // Ajusta la sensibilidad según tus necesidades
            float swipeSensitivity = 1000f;
	    Debug.Log(palmVelocity.x);
            // Verifica si la velocidad en el eje X supera el umbral
            //if (Mathf.Abs(palmVelocity.x) > swipeSensitivity)
            //{
                // Aplica rotación en el eje Y basándose en la dirección de la velocidad
                float rotationAmount = palmVelocity.x > 0 ? 1f : -1f;
                transform.Rotate(Vector3.right, rotationAmount * Time.deltaTime * 50f);
            //}
        }
    }
}