using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteracionarPuerta : MonoBehaviour
{
    public GameObject puertaAbierta, puertaCerrada;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other){             //colisio entre 2 objectes amb triggers marcats(1 o els 2)
        if(other.gameObject.CompareTag("Player")){   //el que xoca porta la etiqueta personatje? (Player)
            puertaAbierta.SetActive(true);          //setActivi fa visible la porta oberta
            puertaCerrada.SetActive(false);         //setActivi fa invisible la porta tancada
        }
    }
    void OnTriggerExit(Collider other){    
        if(other.gameObject.CompareTag("Player")){  //
            puertaAbierta.SetActive(false);
            puertaCerrada.SetActive(true);
        }
    }
}
