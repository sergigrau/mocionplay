using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canviar_Fase : MonoBehaviour
{
    public static int Inv_Fase1;
    public static int Inv_Fase3;
    public Text Num_Fase;
    public Button Jugar;

    public static string Fase;

    
    public void CambiarFase1()
    {
        Jugar.gameObject.SetActive(true);
        Inv_Fase1 = 1;
        Debug.Log("Inv_Fase1: " + Inv_Fase1);
        if (Inv_Fase1 == 1)
        {
            Fase = "Fase 1";
        }
        Inv_Fase3 = 0;
        Debug.Log("Inv_Fase3: " + Inv_Fase3);
        Num_Fase.text = Fase;
    }
    
    public void CambiarFase3()
    {
        Jugar.gameObject.SetActive(true);
        Inv_Fase3 = 1;
        Debug.Log("Inv_Fase3: " + Inv_Fase3);
        if (Inv_Fase3 == 1)
        {
            Fase = "Fase 3";
        }
        Inv_Fase1 = 0;
        Debug.Log("Inv_Fase1: " + Inv_Fase1);
        Num_Fase.text = Fase;
    }
}
