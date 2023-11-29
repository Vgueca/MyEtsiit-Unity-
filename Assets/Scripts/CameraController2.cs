using UnityEngine;
using Leap.Unity;
using Leap;

public class CameraController2: MonoBehaviour
{
    private float _minSwipeDistance = 2.0f;
    private Vector3 derecha = new Vector3(1,0,0);
    private Vector3 arriba = new Vector3(0,1,0);
    public LeapProvider _leapProvider;
    public Transform target;

    private void Start()
    {
    }

    private void OnEnable()
    {
        // Suscribirse al evento de actualización de la mano
        _leapProvider.OnUpdateFrame += OnUpdateFrame;
    }

    private void OnDisable()
    {
        // Desuscribirse del evento de actualización de la mano
        _leapProvider.OnUpdateFrame -= OnUpdateFrame;
    }

    private void OnUpdateFrame(Frame frame)
    {
        if (frame.Hands.Count > 0)
        {
            Hand right = frame.GetHand(Chirality.Right);
	        Hand left = frame.GetHand(Chirality.Left);
            float rotationAmount = 1f;
            float angulo = rotationAmount * Time.deltaTime * 200f;
            
            if(right != null)
            {	
                if (right.PalmVelocity.x > _minSwipeDistance || right.PalmVelocity.x < -_minSwipeDistance)
                {
                    if(right.PalmVelocity.x < -_minSwipeDistance)
                        angulo *= -1;
                    transform.RotateAround(target.position, arriba, angulo);
                }

                if (right.PalmVelocity.y > _minSwipeDistance || right.PalmVelocity.y < -_minSwipeDistance)
                {
                    if(right.PalmVelocity.y < -_minSwipeDistance)
                        angulo *= -1;
                    transform.RotateAround(target.position, derecha, angulo);
                }		

            }

            if(left != null)
            {	
                
                if (left.PalmVelocity.x < -_minSwipeDistance || left.PalmVelocity.x > _minSwipeDistance)
                {
                    if(left.PalmVelocity.x < -_minSwipeDistance)
                        angulo *= -1;
                    transform.RotateAround(target.position, arriba, angulo);
                }
            
                if (left.PalmVelocity.y < -_minSwipeDistance || left.PalmVelocity.y > _minSwipeDistance)
                {
                    if(left.PalmVelocity.y < -_minSwipeDistance)
                        angulo *= -1;
                    transform.RotateAround(target.position, derecha, angulo);
                }
            }
        }
	}
}