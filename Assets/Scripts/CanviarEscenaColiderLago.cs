using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CanviarEscenaColiderLago : MonoBehaviour
{
    public int indiceEscana;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other){             //colisio entre 2 objectes amb triggers marcats(1 o els 2)
        if (other.gameObject.CompareTag("Player"))  //el que xoca porta la etiqueta personatje? (Player)
        {
            SceneManager.LoadScene("Scenes/lago");
        } 

    }
}
