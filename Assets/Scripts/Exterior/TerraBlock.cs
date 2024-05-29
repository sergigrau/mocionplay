using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerraBlock : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!GlobalVariables.Te_Pala)
        {
            Debug.Log("Necesito pala");
            return;            
        }
        Debug.Log("Detectat pala");
        GlobalVariables.Terra_Esta_Excavada = true;
    }
}
