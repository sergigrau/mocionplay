using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detectar_Samira : MonoBehaviour
{
    public GameObject Script_Activar_Dialeg;
    
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Script_Activar_Dialeg.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        Script_Activar_Dialeg.SetActive(false);
    }
}
