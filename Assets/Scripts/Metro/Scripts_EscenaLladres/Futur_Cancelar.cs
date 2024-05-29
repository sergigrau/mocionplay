using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Futur_Cancelar : MonoBehaviour
{
    public GameObject Escena_Parar_Futur;
    public GameObject Escena_Avia_Futur;
    public GameObject Escena_Lladres;
    
    public void Cancelar_Futur()
    {
        Escena_Lladres.SetActive(true);
        Escena_Parar_Futur.SetActive(false);
        Escena_Avia_Futur.SetActive(false);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
