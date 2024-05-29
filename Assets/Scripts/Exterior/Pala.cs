using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pala : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GlobalVariables.Te_Pala = true;
        Debug.Log(GlobalVariables.Te_Pala);
    }
}
