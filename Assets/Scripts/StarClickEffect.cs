using System.Collections;
using UnityEngine;

public class StarClickEffect : MonoBehaviour
{
    public ParticleSystem starEffect;

    public void PlayStarEffect()
    {
        Debug.Log("PlayStarEffect <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
        starEffect.Play();
        // Iniciar una corrutina para detener el sistema de partículas después de un retraso
        StartCoroutine(StopStarEffectAfterDelay(1f)); // 1 segundo de retraso
    }

    public void UpdatePosition(Vector2 screenPosition)
    {
        float distanceFromCamera = 1.88f; // Ajusta este valor según sea necesario
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(screenPosition.x+2f, screenPosition.y, distanceFromCamera));
        starEffect.transform.position = worldPosition;
    }

    // Corrutina para detener el sistema de partículas después de un retraso
    IEnumerator StopStarEffectAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        starEffect.Stop();
    }
}
