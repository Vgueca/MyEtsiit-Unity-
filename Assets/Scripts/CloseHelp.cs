using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseHelp : MonoBehaviour
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
        Debug.Log("Iniciando");
        this.gameObject.SetActive(true);
    }

    //disable gameobject
    public void disable(){
        Debug.Log("Iniciando");
        this.gameObject.SetActive(false);
    }
}
