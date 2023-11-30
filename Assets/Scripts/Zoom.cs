using UnityEngine;
using Leap.Unity;
using Leap;

public class Zoom : MonoBehaviour
{
    private float acumulative = 0.3f;

    private void Start()
    {
    }

    public void Increase()
    {
        float scale = Time.deltaTime * 0.2f;
        if(acumulative + scale < 0.6f)
            acumulative += scale;
        this.transform.localScale = new Vector3(acumulative,acumulative,acumulative);
	}

    public void Decrease()
    {
        float scale = Time.deltaTime * 0.2f;
        if(acumulative - scale > 0.2f)
            acumulative -= scale;
        this.transform.localScale = new Vector3(acumulative,acumulative,acumulative);
    }

    public void Restart()
    {
        acumulative = 0.3f;
        this.transform.localScale = new Vector3(acumulative,acumulative,acumulative);
    }
}