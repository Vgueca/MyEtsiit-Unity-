using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //able gameobject
    public void able(){
        this.gameObject.SetActive(true);
    }

    //disable gameobject
    public void disable(){
        this.gameObject.SetActive(false);
    }

    public void ableTemporal(){
       
        this.gameObject.SetActive(true);
        // Desactiva el objeto después de 8 segundos
        Invoke("disable", 8.0f);

    }
}
