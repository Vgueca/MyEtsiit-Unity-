using UnityEngine;
using Leap.Unity;
using Leap;

public class Zoom : MonoBehaviour
{
    private void Start()
    {
    }

    public void Increase()
    {
        float scale = 1.1f;
        this.transform.localScale = new Vector3(scale,scale,scale);
	}

    public void Decrease()
    {
        float scale = 0.9f;
        this.transform.localScale = new Vector3(scale,scale,scale);
    }
}