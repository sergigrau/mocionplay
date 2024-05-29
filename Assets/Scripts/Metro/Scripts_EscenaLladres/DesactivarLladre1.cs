using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivarLladre1 : MonoBehaviour
{
    public GameObject Ladron1;
    public GameObject Empty_Escena;
    public static int Inv_SalirLadron1 = 0;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ladron1"))
        {
            Inv_SalirLadron1 = 1;
            Ladron1.SetActive(false);
            Empty_Escena.SetActive(false);
        }
    }
}
