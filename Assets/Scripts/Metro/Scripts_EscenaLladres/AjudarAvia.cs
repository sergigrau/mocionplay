using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AjudarAvia : MonoBehaviour
{
    public GameObject Escena_Lladres;
    public GameObject Escena_Avia_Futur;
    public static int Inv_AjudarAvia;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Ajudar()
    {
        //ReanudarTiempo();
        Inv_AjudarAvia = 1;
        Escena_Avia_Futur.SetActive(false);
        Escena_Lladres.SetActive(false);
    }
    public void ReanudarTiempo()
    {
        Time.timeScale = 1f;
        Debug.Log("Tiempo reanudado");
        Ajudar();
    }
}
