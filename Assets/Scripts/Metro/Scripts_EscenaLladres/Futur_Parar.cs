using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Futur_Parar : MonoBehaviour
{
    public GameObject Escena_Parar_Futur;
    public GameObject Escena_Lladres;
    
    public void Parar_Futur()
    {
        Escena_Lladres.SetActive(false);
        Escena_Parar_Futur.SetActive(true);
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
